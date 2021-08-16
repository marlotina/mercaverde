using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Queries.Brands;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Brands
{
    public class BrandQueryReposiroty : QueryBase, IBrandQueryReposiroty
    {
        public BrandQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public Brand GetBrandById(int brandId)
        {
            return Context.Brand.FirstOrDefault(b => b.IdBrand == brandId);
        }

        public IList<Brand> ListBrandsByUserId(int userId)
        {
            return Context.Brand.Where(b => b.UserId == userId).ToList();
        }
    }
}
