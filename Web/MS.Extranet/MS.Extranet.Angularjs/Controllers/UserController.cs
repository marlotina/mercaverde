using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;
using MS.CommandQuery.Core.Commands.Users;
using MS.CommandQuery.Core.Queries.Users;
using MS.Extranet.Angularjs.Base;
using MS.Extranet.Angularjs.Models;

namespace MS.Extranet.Angularjs.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserQueryReposiroty _userQueryReposiroty;
        private readonly ICommandExecutor _commandExecutor;

        public UserController()
        {
            
        }
        public UserController(IUserQueryReposiroty userQueryReposiroty, ICommandExecutor commandExecutor)
        {
            _userQueryReposiroty = userQueryReposiroty;
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        [Authorize]
        public Users.User Get(int id)
        {
            var user = _userQueryReposiroty.GetUserById(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new Users.User()
            {
                IdUser = user.IdUser,
                Name = user.Name,
                Email = user.Email,
                PostalCode = user.PostalCode,
                Surname = user.Surname,
                AcceptedConditions = user.AcceptedConditions,
                IsCompany = user.IsCompany,
                LanguageId = user.LanguageId,
                Photo = !string.IsNullOrEmpty(user.Photo) ? ConfigurationManager.AppSettings["ProfileImagesUrl"] + user.Photo : "/Images/DefaultProfile.jpg",
                CityName = user.CityName,
                BirthDay = user.BirthDate.HasValue ? user.BirthDate.Value.Day : 0,
                BirthMonth = user.BirthDate.HasValue ? user.BirthDate.Value.Month : 0,
                BirthYear = user.BirthDate.HasValue ? user.BirthDate.Value.Year : 0,
                CountryId = user.CountryId,
                Description = user.Description,
                UrlWebSite = user.UrlWebSite,
                InitialLanguageId = user.LanguageId
            };
        }

        [HttpPost]
        [Authorize]
        [Route("api/User/")]
        public HttpResponseMessage Post(Users.User user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (user.IdUser == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var commands = new List<ICommand>
                {
                    new SaveUserCommand()
                    {
                        IdUser = user.IdUser,
                        Name = user.Name,
                        Email = user.Email,
                        PostalCode = user.PostalCode,
                        Surname = user.Surname,
                        CountryId = user.CountryId,
                        Description = user.Description,
                        BirthDate = user.BirthYear + "-" + user.BirthMonth + "-" + user.BirthDay,
                        CityName = user.CityName,
                        Photo = String.Empty,
                        AcceptedConditions = user.AcceptedConditions.HasValue && user.AcceptedConditions.Value,
                        IsCompany = user.IsCompany.HasValue && user.IsCompany.Value,
                        LanguageId = user.LanguageId.HasValue ? user.LanguageId.Value : 1,
                        UrlWebSite = user.UrlWebSite,
                        Action = 1
                    },
                };

                _commandExecutor.Execute(commands);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ExtranetResources.Resources.SaveOk);
        }

        [HttpPost]
        [Authorize]
        [Route("api/User/ResetPassword/")]
        public HttpResponseMessage Post(Users.ChangePassword changePasswordItem)
        {
            try
            {
                var user = _userQueryReposiroty.GetUserById(changePasswordItem.IdUser);

                if (user.Password == Utils.PasswordHelper.EncodePassword(changePasswordItem.Password))
                {
                    var commands = new List<ICommand>
                    {
                        new SaveUserCommand
                        {
                            NewPassword = changePasswordItem.NewPassword, 
                            Action = 3, 
                            IdUser = changePasswordItem.IdUser
                        },
                    };

                    _commandExecutor.Execute(commands);

                    return Request.CreateResponse(HttpStatusCode.OK, ExtranetResources.Resources.SaveOk);
                }

                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, ExtranetResources.Resources.PasswordNotValid);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ExtranetResources.Resources.InternalError));
            }
        }

        [HttpPost]
        [Route("api/User/UploadImages")]
        public HttpResponseMessage UploadImage()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files["Filedata"];
                    var userId = int.Parse(HttpContext.Current.Request.QueryString["userId"]);

                    if (httpPostedFile != null)
                    {
                        var fileName = httpPostedFile.FileName;

                        var listFileName = fileName.Split('.');

                        var fileSavePath = Path.Combine(ConfigurationManager.AppSettings["ProfileImagesFolder"], userId + "." + listFileName[1]);

                        if (File.Exists(fileSavePath))
                        {
                            try
                            {
                                File.Delete(fileSavePath);
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        
                        httpPostedFile.SaveAs(fileSavePath);

                        var commands = new List<ICommand>
                        {
                            new SaveUserCommand()
                            {
                                IdUser = userId,
                                Photo = userId + "." + listFileName[1],
                                Action = 2
                            },
                        };

                        _commandExecutor.Execute(commands);

                        var url = ConfigurationManager.AppSettings["ProfileImagesUrl"] + userId + "." + listFileName[1];
                        return Request.CreateResponse(HttpStatusCode.OK, url);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, ExtranetResources.Resources.CouldNotGetUploadedFile);
                }

                return Request.CreateResponse(HttpStatusCode.OK, ExtranetResources.Resources.NotFileToUpload);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ExtranetResources.Resources.InternalError);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/User/DeleteImage/{userId}")]
        public HttpResponseMessage DeleteImage(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
                }
                    
                var commands = new List<ICommand>
                {
                    new SaveUserCommand()
                    {
                        IdUser = userId,
                        Photo = null,
                        Action = 4
                    },
                };

                _commandExecutor.Execute(commands);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/User/Contact/")]
        public HttpResponseMessage Contact(Contacts.Contact contact)
        {
            try
            {
                var commands = new List<ICommand>
                {
                    new SaveSuggestingCommand()
                    {
                        UserId = contact.UserId,
                        Subject = contact.Subject,
                        Text = contact.Text
                    },
                };

                _commandExecutor.Execute(commands);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }
        }
    }
}
