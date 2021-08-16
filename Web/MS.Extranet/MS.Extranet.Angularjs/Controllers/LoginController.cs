using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Queries.Users;
using MS.Extranet.Angularjs.Base;
using MS.Extranet.Angularjs.Models;
using MS.Utils;

namespace MS.Extranet.Angularjs.Controllers
{
    public class LoginController : CustomController
    {
        IUserQueryReposiroty _userQueryRepository { get; set; }

        private readonly ICommandExecutor _commandExecutor;

        public LoginController(IUserQueryReposiroty userQueryRepository, ICommandExecutor commandExecutor)
        {
            _userQueryRepository = userQueryRepository;
            _commandExecutor = commandExecutor;
        }

        public ActionResult Login()
        {
            
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["ActivationCode"]))
            {
                var code = PasswordHelper.Base64Decode(HttpContext.Request.QueryString["ActivationCode"]).Split(',');
                var user = _userQueryRepository.GetUserByEmail(code[0]);

                if (user == null || code[1] != user.Password)
                {
                    ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.PasswordOrUserNotValid);
                    return RedirectToAction("Login", "Login"); 
                }

                var commands = new List<ICommand>
                {
                    new SaveUserCommand()
                    {
                        IdUser = user.IdUser,
                        Action = 5
                    },
                };
                _commandExecutor.Execute(commands);

                StartSession(user, false);

                return RedirectToAction("Index", "Home"); 
            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["LogOut"]))
            {
                Session["currentUser"] =  null;
                FormsAuthentication.SignOut();
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Logins.Login contact)
        {
            var user = _userQueryRepository.GetUserByEmail(contact.Email);

            //if (user == null || PasswordHelper.EncodePassword(contact.Password) != user.Password)
            //{
            //    ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.PasswordOrUserNotValid);
            //    return View(contact);
            //}

            StartSession(user, contact.RememberMe);

            return RedirectToAction("Index", "Home");
        }

        private void StartSession(User user, bool rememberMe)
        {
            CurrentUser = new CurrentUserInfo()
            {
                LanguageId = user.LanguageId ?? 1,
                UserId = user.IdUser,
                UserName = user.Name,
                LanguageCode = user.Language == null ? LanguageHelper.DefaultLanguage : user.Language.CultureName,
                ImageProfile = !string.IsNullOrEmpty(user.Photo) ? ConfigurationManager.AppSettings["ProfileImagesUrl"] + user.Photo : string.Empty,
                Email = user.Email 
            };

            Session["currentUser"] = CurrentUser;

            FormsAuthentication.SetAuthCookie(user.IdUser.ToString(), rememberMe);
        }

        [HttpPost]
        public ActionResult Register(Logins.Register newUser)
        {
            if (ModelState.IsValid)
            {
                if (!newUser.AcceptedConditions)
                {
                    ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.YouMustAcceptConditions);
                }
                else
                {
                    if (_userQueryRepository.GetUserByEmail(newUser.Email) != null)
                    {
                        ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.UserExist);
                    }
                    else
                    {
                        try
                        {
                            var commands = new List<ICommand>
                            {
                                new AddUserCommand()
                                {
                                    Email = newUser.Email,
                                    Password = newUser.Password,
                                    Name = newUser.Name,
                                    Surname = newUser.Surname,
                                    AcceptedConditions = newUser.AcceptedConditions,
                                    LanguageId = LanguageHelper.GetLanguageIdFromUrlCulture(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
                                },
                            };
                            _commandExecutor.Execute(commands);

                            TempData["Success"] = ExtranetResources.Resources.WeSendActivationMail;
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.InternalError);
                        }
                    }   
                }
            }

            return View(newUser);
        }

        [HttpPost]
        public ActionResult RecoverPassword(Logins.RecoverPassword contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var commands = new List<ICommand>
                    {
                        new RecoverPasswordCommand()
                        {
                            Email = contact.Email,
                        },
                    };

                    _commandExecutor.Execute(commands);

                    TempData["Success"] = ExtranetResources.Resources.WeSendMailWithYouPassword;
                }
                catch(CommandException ex)
                {
                    if (ex.Message == "UserNotExist")
                    {
                        ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.UserNotExist);
                    }

                    ModelState.AddModelError("ErrorMessage", ex.Message);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ErrorMessage", ExtranetResources.Resources.InternalError);
                }
            }

            return View(contact);
        }
    }
}