using System;
using System.Configuration;
using System.Net.Mail;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;
using MS.CommandQuery.Core.Entities.Tasks;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.Utils;
using StructureMap;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Users
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IMsContext _context;

        IMailTemplateQueryRepository _mailTemplateQueryRepository { get; set; }

        public AddUserCommandHandler(IMsContext context)
        {
            _mailTemplateQueryRepository = ObjectFactory.GetInstance<IMailTemplateQueryRepository>();
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (AddUserCommand)commandObj;

                var user = new User();
                user.Name = command.Name;
                user.Surname = command.Surname;
                user.Email = command.Email;
                user.Password = PasswordHelper.EncodePassword(command.Password);
                user.AcceptedConditions = command.AcceptedConditions;
                user.MailActivation = false;
                user.LanguageId = command.LanguageId;
                
                var mailToSend = LoadMail(user);

                if (MailHelper.SendMail(mailToSend))
                {
                    user.TaskProcesses.Add(new TaskProcess()
                    {
                        Status = (int)EnumStatusTask.Completed,
                        TaskProcessType = (int)EnumTaskProcessType.Register,
                        User = user,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Attempts = 0
                    });
                }
                else
                {
                    user.TaskProcesses.Add(new TaskProcess()
                    {
                        Status = (int)EnumStatusTask.Pending,
                        TaskProcessType = (int)EnumTaskProcessType.Register,
                        User = user,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Attempts = 0
                    });
                }

                _context.User.Add(user);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new CommandException("AddUserCommandHandler", ex.Message);
            }
        }

        private MailMessage LoadMail(User user)
        {
            var msg = new MailMessage { IsBodyHtml = true };

            try
            {
                var mailTemplate = _mailTemplateQueryRepository.GetMailTemplateByLanguageId(
                    EnumMailTemplate.Activation, user.LanguageId ?? 1);

                msg.From = new MailAddress("info@elmercadoverde.es");
                if (ConfigurationManager.AppSettings["IsDebug"] == "True")
                {
                    msg.To.Add(ConfigurationManager.AppSettings["debugMail"]);
                }
                else
                {
                    msg.To.Add(user.Email);
                    foreach (var mail in mailTemplate.WithCopy.Split(','))
                    {
                        msg.Bcc.Add(mail);
                    }
                }

                msg.Priority = MailPriority.High;
                msg.Subject = mailTemplate.Subject;
                var code = Utils.PasswordHelper.Base64Encode(user.Email + "," + user.Password);
                var urlActivation = ConfigurationManager.AppSettings["MSDomain"] + LanguageHelper.GetUrlCultureFromLanguageId((int)user.LanguageId)+ "/Login/Login?ActivationCode=" + code;
                msg.Body = mailTemplate.Text.Replace("##ActivationUrl##", urlActivation);
            }
            catch (Exception ex)
            {
                throw new CommandException("AddUserCommandHandler", "LoadMail");
            }

            return msg;
        }
    }
}
