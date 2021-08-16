using System.Data.Entity.ModelConfiguration;
using MS.CommandQuery.Core.Entities.Users;

namespace MS.CommandQuery.Infrastructure.DbConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {

        }
    }
}