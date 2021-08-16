using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Core.Queries.Users
{
    public interface IUserQueryReposiroty
    {
        User GetUserById(int userId);

        User GetUserByEmail(string email);
    }
}
