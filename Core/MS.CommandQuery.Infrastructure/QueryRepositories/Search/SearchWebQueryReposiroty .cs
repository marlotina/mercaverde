using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Search;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Search
{
    public class SearchWebQueryReposiroty : QueryBase, ISearchWebQueryReposiroty
    {
        public SearchWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public SearchStoreItem GetStoresWebSearchByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int order, string labels)
        {
            var storeList = new SearchStoreItem();
            storeList.ListStores = StoresWebSearchListByFilter(locationId, languageId, districts, categories, startItem, numItems, order, labels);
            storeList.NumItems = numItems;
            storeList.StartItem = startItem;


            if (storeList.ListStores.Any())
                storeList.TotalItems = storeList.ListStores.FirstOrDefault().TotalItems;
            
            return storeList;
        }

        public SearchMapStoreItem GetStoresWebSearchMapByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int order, string labels)
        {
            var storeList = new SearchMapStoreItem();

            storeList.ListStores = StoresWebSearchMapByFilter(locationId, languageId, districts, categories, startItem, numItems, order, labels);
            storeList.StoresPoints = StoresWebSearchMapFullByFilter(locationId, districts, categories);
            storeList.NumItems = numItems;
            storeList.StartItem = startItem;
            
            //var city = Context.City.FirstOrDefault(c => c.IdCity == locationId);

            //if (city != null)
            //{
                storeList.CenterLongitude = "2.148767850000013";//city.Longitude.ToString();
                storeList.CenterLatitude = "41.39483307195536";//city.Latitude.ToString();
            //}

            if (storeList.StoresPoints.Any())
                storeList.TotalItems = storeList.StoresPoints.Count();

            return storeList;
        }

        private IEnumerable<SearchItem> StoresWebSearchListByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int order, string labels)
        {
            const string query =
                "EXEC spWebSearchList @IdLocation = {0},  @LanguageId = {1}, @districtsList = '{2}', @categoryList = '{3}', @startItem = {4}, @numItems = {5}, @order = {6}, @labelList = '{7}'";

            var qlQuery = string.Format(query, locationId, languageId, districts, categories, startItem, numItems, order, labels);
            return Context.Database.SqlQuery<SearchItem>(qlQuery).ToList();
        }

        private IEnumerable<SearchItem> StoresWebSearchMapByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int order, string labels)
        {
            const string query =
                "EXEC spWebSearchMap @IdLocation = {0},  @LanguageId = {1}, @districtsList = '{2}', @categoryList = '{3}', @startItem = {4}, @numItems = {5}, @order = {6}, @labelList = '{7}'";

            var qlQuery = string.Format(query, locationId, languageId, districts, categories, startItem, numItems, order, labels);

            return Context.Database.SqlQuery<SearchItem>(qlQuery).ToList();
        }

        private IEnumerable<ListMapItem> StoresWebSearchMapFullByFilter(int locationId, string districts, string categories)
        {
            const string query =
                "EXEC spWebSearchMapFull @IdLocation = {0}, @districtsList = '{1}', @categoryList = '{2}'";

            var qlQuery = string.Format(query, locationId, districts, categories);

            return Context.Database.SqlQuery<ListMapItem>(qlQuery).ToList();
        }
    }
}