using System.Web.Http;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Search;
using MS.CommandQuery.Core.Queries.Stores;
using MS.Utils;
using MS.Web.Models;

namespace MS.Web.Controllers
{
    public class SearchsController : ApiController
    {
        private readonly ISearchWebQueryReposiroty _searchWebQueryReposiroty;

        private readonly IStoreWebQueryReposiroty _storeWebQueryReposiroty;

        public SearchsController(ISearchWebQueryReposiroty searchWebQueryReposiroty, IStoreWebQueryReposiroty storeWebQueryReposiroty)
        {
            _searchWebQueryReposiroty = searchWebQueryReposiroty;
            _storeWebQueryReposiroty = storeWebQueryReposiroty;
        }

        [HttpPost]
        [Route("api/Search/List/")]
        public SearchStoreItem List(Search.Filter filters)
        {
            var listStores = _searchWebQueryReposiroty.GetStoresWebSearchByFilter(filters.IdLocation, filters.LanguageId, string.Join(",", filters.DistrictsList), string.Join(",", filters.CategoryList), filters.StartItem, filters.NumItems, filters.Order, string.Join(",", filters.LabelList));

            foreach (var store in listStores.ListStores)
            {
                if (string.IsNullOrEmpty(store.ImageUrl))
                {
                    store.ImageUrl = "../img/image-not-found.png";
                }

                store.Url = UrlHelper.GetStoreUrl(store.IdStore, filters.LanguageId);
            }
            
            return listStores;
        }

        [HttpPost]
        [Route("api/Search/Map/")]
        public SearchMapStoreItem Map(Search.Filter filters)
        {
            var listStores = _searchWebQueryReposiroty.GetStoresWebSearchMapByFilter(filters.IdLocation, filters.LanguageId, string.Join(",", filters.DistrictsList), string.Join(",", filters.CategoryList), filters.StartItem, filters.NumItems, filters.Order, string.Join(",", filters.LabelList));

            foreach (var store in listStores.ListStores)
            {
                if (string.IsNullOrEmpty(store.ImageUrl))
                {
                    store.ImageUrl = "../img/image-not-found.png";
                }

                store.Url = UrlHelper.GetStoreUrl(store.IdStore, filters.LanguageId);
            }

            return listStores;
        }

        [HttpGet]
        [Route("api/Search/Map/StoreInfo/{storeId:int}/{languageId:int}")]
        public SearchItem StoreInfo(int storeId, int languageId)
        {
            var store = _storeWebQueryReposiroty.GetStoreForMapById(storeId);
            store.Url = UrlHelper.GetStoreUrl(store.IdStore, languageId);

            return store;
        }
    }
}