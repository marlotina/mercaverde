using System;
using System.IO;
using System.Linq;
using System.Web;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Users
{
    public class ModifyUserCommandHandler : ICommandHandler<SaveUserCommand>
    {
        private readonly IMsContext _context;

        public ModifyUserCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveUserCommand)commandObj;
            try
            {
                var user = _context.User.FirstOrDefault(u => u.IdUser == command.IdUser);

                if (user != null)
                {
                    if (command.Action == 1)
                    {
                        DateTime date;
                        user.Name = command.Name;
                        user.Surname = command.Surname;
                        user.PostalCode = command.PostalCode;
                        user.IsCompany = command.IsCompany;
                        user.AcceptedConditions = command.AcceptedConditions;
                        user.Language = _context.Language.First(l => l.IdLanguage == command.LanguageId);
                        user.Country = command.CountryId != null ? _context.Country.First(c => c.IdCountry == command.CountryId) : null;
                        user.Description = command.Description;
                        user.BirthDate = DateTime.TryParse(command.BirthDate, out date) ? date : (DateTime?)null;
                        user.Street = command.Street;
                        user.NumberStreet = command.Street;
                        user.Email = command.Email;
                        user.CityName = command.CityName;
                        user.Description = command.Description;
                        user.CityName = command.CityName;
                        user.UrlWebSite = command.UrlWebSite;
                    }
                    else if (command.Action == 2)
                    {
                        if (!string.IsNullOrEmpty(command.Photo))
                        {
                            user.Photo = command.Photo;
                        }
                    }
                    else if (command.Action == 3)
                    {
                        user.Password = MS.Utils.PasswordHelper.EncodePassword(command.NewPassword);
                    }
                    else if (command.Action == 4)
                    {
                        var image = user.Photo;

                        if (!string.IsNullOrEmpty(image))
                        {
                            var fileSavePath = HttpContext.Current.Server.MapPath(user.Photo);

                            if (File.Exists(fileSavePath))
                            {
                                File.Delete(fileSavePath);
                            }

                            user.Photo = null;
                        } 
                    }
                    else if (command.Action == 5)
                    {
                        user.MailActivation = true;
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("ModifyUserCommandHandler", ex.Message);
            }
        }
    }
}
