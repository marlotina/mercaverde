using System;
using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Brands
{
    public class SaveBrandCommand : ICommand
    {
        public int IdBrand { get; set; }

        public string Name { get; set; }
 
        public string Email  { get; set; }

        public string PrefixPhone { get; set; }
        
        public string Phone  { get; set; }

        public bool IsPublished { get; set; }

        public bool Validate  { get; set; }
        
        public int DistrictId { get; set; }

        public string TimeTable { get; set; }

        public int UserId { get; set; }

        public int[] Labels { get; set; }
        
        public int CityId { get; set; }


        public string Street { get; set; }

        public string Number { get; set; }

        public string PostalCode { get; set; }

        public string UrlWebSite { get; set; }
    }
}