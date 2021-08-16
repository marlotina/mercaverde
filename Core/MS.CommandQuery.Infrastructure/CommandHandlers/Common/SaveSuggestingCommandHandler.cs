using System;
using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Common
{
    public class SaveSuggestingCommandHandler: ICommandHandler<SaveSuggestingCommand>
    {
        private readonly IMsContext _context;

        public SaveSuggestingCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveSuggestingCommand)commandObj;

            

            var user = _context.User.FirstOrDefault(u => u.IdUser == command.UserId);

            if (user != null)
            {
                var suggesting = new Suggesting
                {
                    CreateDate = DateTime.Now,
                    Email = user.Email,
                    Subject = command.Subject,
                    Text = command.Text,
                    Revised = false, 
                    UserId = command.UserId
                };

                if (!string.IsNullOrEmpty(command.Email))
                {
                    suggesting.Email = command.Email;
                }

                user.Suggestings.Add(suggesting);
            }
            
            _context.SaveChanges();
        }
    }
}
