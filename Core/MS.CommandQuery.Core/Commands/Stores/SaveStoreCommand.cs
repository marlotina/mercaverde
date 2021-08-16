using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{ 
    public class SaveStoreCommand :ICommand
    {
        public int IdStore { get; set; }

        public string Name { get; set; }
 
        public string Email  { get; set; }

        public string Phone  { get; set; }

        public bool IsPublished { get; set; }

        public string StreetComplete { get; set; }

        public int? DistrictId { get; set; }

        public string TimeTable { get; set; }

        public int UserId { get; set; }

        public int? CityId { get; set; }
        
        public string UrlWebSite { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool Validate  { get; set; }

        public string PrefixPhone { get; set; }

        public string MobilePhone { get; set; }

        public string PostalCode { get; set; }

        //public string Neighborhood { get; set; }
    }
}