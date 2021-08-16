namespace MS.Extranet.Angularjs.Models
{
    public class Users
    {
        public class User
        {
            public int IdUser { get; set; }

            public string Email { get; set; }

            public int? CountryId { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }

            public int? LanguageId { get; set; }

            public bool? AcceptedConditions { get; set; }

            public string PostalCode { get; set; }

            public bool? IsCompany { get; set; }

            public string Street { get; set; }

            public string NumberStreet { get; set; }

            public string CityName { get; set; }

            public string Description { get; set; }

            public string Photo { get; set; }

            public string UrlWebSite { get; set; }
            
            public int BirthDay { get; set; }

            public int BirthMonth { get; set; }

            public int BirthYear { get; set; }

            public string LanguageUrl { get; set; }

            public int? InitialLanguageId { get; set; }
        }

        public class ChangePassword
        {
            public int IdUser { get; set; }

            public string Password { get; set; }

            public string NewPassword { get; set; }
        }
    }
}