using System.Collections.Generic;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Product;

namespace MS.CommandQuery.Core.Queries.Stores
{
    public interface IStoreQueryReposiroty
    {
        Store GetStoreById(int storeId);

        Store GetStoreByName(string name);

        IList<Store> GetStoresByUserId(int userId);

        IList<StoreDescription> GetStoreDescriptionsByStoreId(int storeId);

        IList<StoreImage> GetStoreImagesByStoreId(int storeId);

        IList<Category> GetStoreCategoriesByStoreId(int storeId);

        IList<Label> GetStoreLabelsByStoreId(int storeId);
    }
}
