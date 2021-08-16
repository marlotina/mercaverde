using System.Data.Entity.ModelConfiguration;
using MS.CommandQuery.Core.Entities.Product;

namespace MS.CommandQuery.Infrastructure.DbConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Store>
    {
        public DepartmentConfiguration()
        {
        }
    }
}