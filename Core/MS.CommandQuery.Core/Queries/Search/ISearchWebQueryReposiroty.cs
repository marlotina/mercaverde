using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Search
{
    public interface ISearchWebQueryReposiroty
    {
        SearchStoreItem GetStoresWebSearchByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int orde, string labels);

        SearchMapStoreItem GetStoresWebSearchMapByFilter(int locationId, int languageId, string districts, string categories, int startItem, int numItems, int order, string labels);
    }
}
