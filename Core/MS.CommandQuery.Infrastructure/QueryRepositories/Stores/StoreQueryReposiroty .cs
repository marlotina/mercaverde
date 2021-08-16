using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Queries.Stores;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Stores
{
    public class StoreQueryReposiroty : QueryBase, IStoreQueryReposiroty
    {
        public StoreQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public Store GetStoreById(int storeId)
        {
            return Context.Store.FirstOrDefault(s => s.IdStore == storeId);
        }

        public Store GetStoreByName(string name)
        {
            return Context.Store.FirstOrDefault(s => s.Name == name);
        }

        public IList<Store> GetStoresByUserId(int userId)
        {
            return Context.Store.Where(s => s.UserId == userId && s.Deleted == false).ToList();
        }

        public IList<StoreDescription> GetStoreDescriptionsByStoreId(int storeId)
        {
            return Context.StoreDescription.Where(s => s.StoreId == storeId).ToList();
        }

        public IList<StoreImage> GetStoreImagesByStoreId(int storeId)
        {
            return Context.StoreImage.Where(s => s.StoreId == storeId).OrderBy(s => s.Order).ToList();
        }

        public IList<Category> GetStoreCategoriesByStoreId(int storeId)
        {
            var store = Context.Store.FirstOrDefault(s => s.IdStore == storeId);
            if (store != null && store.Categories.Any())
            {
                return store.Categories.ToList();
            }
            return new List<Category>();
        }

        public IList<Label> GetStoreLabelsByStoreId(int storeId)
        {
            var store = Context.Store.FirstOrDefault(s => s.IdStore == storeId);
            if (store != null && store.Labels.Any())
            {
                return store.Labels.ToList();
            }
            return new List<Label>();
        }
    }
}
