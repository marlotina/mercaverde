using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Stores;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Stores
{
    public class StoreWebQueryReposiroty : QueryBase, IStoreWebQueryReposiroty
    {
        public StoreWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public SearchItem GetStoreForMapById(int storeId)
        {
            var result = new SearchItem();
            var store = Context.Store.FirstOrDefault(s => s.IdStore == storeId);

            result.IdStore = store.IdStore;
            result.ImageUrl = "../img/image-not-found.png";
            result.Name = store.Name;
            return result;
        }

        public IEnumerable<SearchItem> GetLastStoresWebSearch(int languageId)
        {
            const string query =
                "EXEC spGetLastStores @LanguageId = {0}";
            var qlQuery = string.Format(query, languageId);

            return Context.Database.SqlQuery<SearchItem>(qlQuery).ToList();
        }

        public StoreDetail GetStoreDetailsForWeb(int storeId, int languageId)
        {
            const string query = "EXEC spGetStoreDetail @storeId = {0},  @LanguageId = {1}";
            var qlQuery = string.Format(query, storeId, languageId);

            var store = Context.Database.SqlQuery<StoreDetail>(qlQuery).ToList().First();
            store.StoreImages = Context.StoreImage.Where(s => s.StoreId == storeId).ToList();
            store.Labels = Context.Store.FirstOrDefault(s => s.IdStore == storeId).Labels.ToList();
            store.Categories = Context.Store.FirstOrDefault(s => s.IdStore == storeId).Categories.ToList();

            return store;
        }

    }
}
