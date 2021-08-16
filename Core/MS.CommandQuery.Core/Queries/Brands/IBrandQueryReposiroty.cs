using System.Collections.Generic;
using MS.CommandQuery.Core.Entities.Product;

namespace MS.CommandQuery.Core.Queries.Brands
{
    public interface IBrandQueryReposiroty
    {
        Brand GetBrandById(int brandId);

        IList<Brand> ListBrandsByUserId(int userId);
    }
}
