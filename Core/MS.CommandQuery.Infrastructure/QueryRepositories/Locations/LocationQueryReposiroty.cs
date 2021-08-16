using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Locations
{
    public class LocationQueryReposiroty: QueryBase, ILocationQueryReposiroty
    {
        public LocationQueryReposiroty(IMsContext context) : base(context)
        {
        }

        public List<ListItem> GetCitiesForComboByLanguage(int languageId, int countryId)
        {
            var cityTranslations = from c in Context.City
                                   join cl in Context.CityLanguage on c.IdCity equals cl.CityId
                                   where cl.LanguageId == languageId
                                   select new ListItem() { Value = c.IdCity.ToString(), Text = cl.Name };

            return cityTranslations.ToList();
        }

        public List<ListItem> GetCountriesForComboByLanguage(int languageId)
        {
            var result = new List<ListItem>();

            foreach (var countryTranslation in Context.CountryLanguage.Where(c => c.LanguageId == languageId))
            {
                result.Add(new ListItem() { Value = countryTranslation.CountryId.ToString(), Text = countryTranslation.Name });
            }

            return result;
        }


        public List<ListItem> GetDistrictsForCombo()
        {
            return Context.District.Where(d => d.Published).OrderBy(d => d.Name).Select(district => new ListItem() 
            {
                Value = district.IdDistrict.ToString(),
                Text = district.Name
            }).ToList();
        }
    }
}