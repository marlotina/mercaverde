using System.Collections.Generic;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Product;

namespace MS.CommandQuery.Core.Model
{
    public class StoreDetail
    {
        public int IdStore { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PrefixPhone { get; set; }

        public string MobilePhone { get; set; }

        public string UrlWebSite { get; set; }

        public string Street { get; set; }

        public string StreetComplete { get; set; }

        public string PostalCode { get; set; }

        public string Number { get; set; }

        public int CityId { get; set; }

        public int? DistrictId { get; set; }

        public string TimeTable { get; set; }

        public int UserId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string CityName { get; set; }

        public string DistrictName { get; set; }

        //public ICollection<StoreComment> StoreComments { get; set; }

        public StoreDescription StoreDescriptions { get; set; }

        public ICollection<StoreImage> StoreImages { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Label> Labels { get; set; }
    }
}
