using System.Collections.Generic;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Stores
{
    public interface IStoreWebQueryReposiroty
    {
        SearchItem GetStoreForMapById(int storeId);

        IEnumerable<SearchItem> GetLastStoresWebSearch(int languageId);

        StoreDetail GetStoreDetailsForWeb(int storeId, int languageId);
    }
}
