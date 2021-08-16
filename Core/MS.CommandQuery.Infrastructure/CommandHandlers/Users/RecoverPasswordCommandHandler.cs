using System;
using System.Configuration;
using System.Linq;
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
    public class RecoverPasswordCommandHandler : ICommandHandler<RecoverPasswordCommand>
    {
        IMailTemplateQueryRepository _mailTemplateQueryRepository { get; set; }

        private readonly IMsContext _context;

        public RecoverPasswordCommandHandler(IMsContext context)
        {
            _mailTemplateQueryRepository = ObjectFactory.GetInstance<IMailTemplateQueryRepository>();
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (RecoverPasswordCommand)commandObj;

                var user = _context.User.FirstOrDefault(u => u.Email == command.Email);

                if (user != null)
                {
                    var newPassword = PasswordHelper.GenerateRandomPassword(7);
                    var mailToSend = this.LoadMail(user, newPassword);

                    user.Password = PasswordHelper.EncodePassword(newPassword);

                    if (MailHelper.SendMail(mailToSend))
                    {
                        user.TaskProcesses.Add(new TaskProcess()
                        {
                            Status = (int)EnumStatusTask.Completed,
                            TaskProcessType = (int)EnumTaskProcessType.RecoverPassword,
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
                            TaskProcessType = (int)EnumTaskProcessType.RecoverPassword,
                            User = user,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            Attempts = 0
                        });
                    }
                    _context.SaveChanges();
                }
                else
                {
                    throw new CommandException("RecoverPasswordCommandHandler", "UserNotExist");
                }
            }
            catch (Exception ex)
            {
                throw new CommandException("RecoverPasswordCommandHandler", ex.Message);
            }
        }

        private MailMessage LoadMail(User user, string password)
        {
            var msg = new MailMessage { IsBodyHtml = true };

            try
            {
                var mailTemplate = _mailTemplateQueryRepository.GetMailTemplateByLanguageId(
                    EnumMailTemplate.RecoverPassword, user.LanguageId ?? 1);

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
                msg.Body = mailTemplate.Text.Replace("##newPassword##", password).Replace("##userName##", user.Name);
            }
            catch (Exception ex)
            {
                throw new CommandException("RecoverPasswordCommandHandler", "LoadMail");
            }

            return msg;
        }
    }
}
