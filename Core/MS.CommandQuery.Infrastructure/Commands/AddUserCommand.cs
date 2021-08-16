using MS.CommandQuery.Core.Commands;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.Commands
{
    public class AddUserCommand : CommandBase, IAddUserCommand
    {
        public AddUserCommand(ISampleDbContext context) : base(context)
        {
        }

        public void Add(User user)
        {
            Context.User.Add(user);
            Context.SaveChanges();
        }
    }
}
