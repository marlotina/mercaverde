using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Users
{
    public class SaveUserCommand : ICommand
    {
        public int IdUser { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

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

        public string NewPassword { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string BirthDate { get; set; }

        public int Action { get; set; }
        
        public string UrlWebSite { get; set; }
    }
}
