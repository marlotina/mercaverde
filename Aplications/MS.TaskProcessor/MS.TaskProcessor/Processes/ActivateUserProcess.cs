using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using log4net;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Task;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Core.Queries.Users;
using StructureMap;

namespace MS.TaskProcessor.Processes
{
    public class ActivateUserProcess
    {
        IMailTemplateQueryRepository _mailTemplateQueryRepository { get; set; }

        IUserQueryReposiroty _userQueryReposiroty { get; set; }

        ICommandExecutor _commandExecutor { get; set; }

        private static readonly ILog Log = LogManager.GetLogger("ActivateUserProcess");

        public ActivateUserProcess()
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
                    var mailToSend = this.LoadMail(user);
                    var status = EnumStatusTask.Pending;

                    if (Utils.MailHelper.SendMail(mailToSend))
                    {

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

                    _commandExecutor.Execute(commands);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Log.Error("ActivateUserProcess.Load: " + ex.Message);
            }
            

            return result;
        }

        private MailMessage LoadMail(User user)
        {
            var msg = new MailMessage {IsBodyHtml = true};

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
                var urlActivation = ConfigurationManager.AppSettings["MSDomain"] + "Login/Login?ActivationCode=" + code;
                msg.Body = mailTemplate.Text.Replace("##ActivationUrl##", urlActivation);
            }
            catch (Exception ex)
            {
                Log.Error("ActivateUserProcess.LoadMail: " + ex.Message);
            }

            return msg;
        }
    }
}
