using System.Collections.Generic;
using System.EnterpriseServices.Internal;

namespace MS.Extranet.Angularjs.Models
{
    public class Stores
    {
        public class Store
        {
            public int IdStore { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            public bool IsPublished { get; set; }

            public string Street { get; set; }

            public int? DistrictId { get; set; }

            public string TimeTable { get; set; }

            public int UserId { get; set; }

            public string Latitude { get; set; }

            public string Longitude { get; set; }

            public int? CityId { get; set; }

            public string PrefixPhone { get; set; }

            public string MobilePhone { get; set; }

            public string PostalCode { get; set; }

            public string LastActivity { get; set; }
        }

        public class StoreDescription
        {
            public int IdStore { get; set; }

            public List<DescriptionItem> DescriptionList { get; set; }
        }

        public class DescriptionItem
        {
            public int IdLanguage { get; set; }

            public string LanguageName { get; set; }

            public string Title { get; set; }

            public string ShortDescription { get; set; }

            public string Description { get; set; }

        }

        public class StoreImage
        {
            public int IdStoreImage { get; set; }

            public int StoreId { get; set; }

            public string ImageUrl { get; set; }

            public int Order { get; set; }

            public bool IsMain { get; set; }
        }

        public class StoreClassification
        {
            public int StoreId { get; set; }

            public List<ItemCheckBox> CategoryList { get; set; }

            public List<ItemCheckBox> LabelList { get; set; }

        }

        public class ItemCheckBox
        {
            public bool Checked { get; set; }

            public int Value { get; set; }

            public string Text { get; set; }
        }

        public class StorePublish
        {
            public int IdStore { get; set; }

            public bool IsPublished { get; set; }

            public bool IsRevised { get; set; }

            public string UrlStore { get; set; }
        }
    }
}