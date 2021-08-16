using System.Collections.Generic;

namespace MS.CommandQuery.Core.Model
{
    public class SearchStoreItem : BaseSearchItem
    {
        public IEnumerable<SearchItem> ListStores { get; set; }
    }

    public class SearchItem
    {
        public int IdStore { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public string DistrictName { get; set; }

        public int? DisctrictId { get; set; }

        public string CityName { get; set; }

        public int TotalItems { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string ShortDescription { get; set; }
    }

    public class SearchMapStoreItem : SearchStoreItem
    {
        public string CenterLatitude { get; set; }

        public string CenterLongitude { get; set; }

        public IEnumerable<ListMapItem> StoresPoints { get; set; } 
    }

    public class ListMapItem
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int IdStore { get; set; }
    }
}
