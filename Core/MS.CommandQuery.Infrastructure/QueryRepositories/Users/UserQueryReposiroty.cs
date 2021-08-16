using System.Linq;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Queries.Users;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Users
{
    public class UserQueryReposiroty : QueryBase, IUserQueryReposiroty
    {
        public UserQueryReposiroty(IMsContext context) : base(context)
        {
        }

        public User GetUserById(int userId)
        {
            var user = Context.User.FirstOrDefault(u => u.IdUser == userId);

            return user;
        }

        public User GetUserByEmail(string email)
        {

            var user = from u in Context.User
                where u.Email.Equals(email)
                select u;

            return user.FirstOrDefault();
        }
    }
}
