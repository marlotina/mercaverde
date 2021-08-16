using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using log4net;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Task;
using MS.CommandQuery.Core.Commands.Users;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Core.Queries.Users;
using StructureMap;

namespace MS.TaskProcessor.Processes
{
    public class RecoverPasswordProcess
    {
        IMailTemplateQueryRepository _mailTemplateQueryRepository { get; set; }

        IUserQueryReposiroty _userQueryReposiroty { get; set; }

        private readonly ICommandExecutor _commandExecutor;

        private static readonly ILog Log = LogManager.GetLogger("ActivateUserProcess");

        public RecoverPasswordProcess()
        {
            _mailTemplateQueryRepository = ObjectFactory.GetInstance<IMailTemplateQueryRepository>();
            _userQueryReposiroty = ObjectFactory.GetInstance<IUserQueryReposiroty>();
            _commandExecutor = ObjectFactory.GetInstance<ICommandExecutor>();
        }

        public bool Load(TaskItem task)
        {
            
            var result = false;
            try
            {
                var user = _userQueryReposiroty.GetUserById(task.UserId);

                if (user != null)
                {
                    var newPassword = Utils.PasswordHelper.GenerateRandomPassword(7);
                    var mailToSend = this.LoadMail(user, newPassword);
                    var status = EnumStatusTask.Pending;

                    if (Utils.MailHelper.SendMail(mailToSend))
                    {
                        result = true;
                        status = EnumStatusTask.Completed;
                    }

                    var commands = new List<ICommand>
                    {
                        new UpdateTaskProcessCommand()
                        {
                            IdTaskProcess = task.IdTaskProcess,
                            Status = status
                        },
                    };

                    commands.Add(new SaveUserCommand()
                    {
                        IdUser = task.UserId,
                        NewPassword = Utils.PasswordHelper.EncodePassword(newPassword),
                        Action = 3
                    });

                    _commandExecutor.Execute(commands);
                }
            }
            catch (Exception ex)
            {
                result = false;
                Log.Error("RecoverPasswordProcess.Load: " + ex.Message);
            }

            return result;
        }

        private MailMessage LoadMail(User user, string password)
        {
            var msg = new MailMessage {IsBodyHtml = true};

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
                Log.Error("RecoverPasswordProcess.LoadMail: " + ex.Message);
            }

            return msg;
        }
    }
}
