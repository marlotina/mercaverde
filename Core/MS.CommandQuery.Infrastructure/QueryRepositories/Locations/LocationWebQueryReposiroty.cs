using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Locations
{
    
    public class LocationWebQueryReposiroty: QueryBase, ILocationWebQueryReposiroty
    {
        public LocationWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public List<ListItem> GetDistrictsForFilter()
        {
            return Context.District.Where(d => d.Published).OrderBy(d => d.Name).Select(district => new ListItem()
            {
                Value = district.IdDistrict.ToString(),
                Text = district.Name
            }).ToList();
        }

        public List<ListItem> GetCitiesForComboByLanguage(int languageId, int countryId)
        {
            var cityTranslations = from c in Context.City
                                   join cl in Context.CityLanguage on c.IdCity equals cl.CityId
                                   where cl.LanguageId == languageId
                                   select new ListItem() { Value = c.IdCity.ToString(), Text = cl.Name };

            return cityTranslations.ToList();
        }

        public LocationItem GetCityById(int cityId)
        {
            var city = Context.City.FirstOrDefault(c => c.IdCity == cityId);

            if (city != null)
            {
                return new LocationItem()
                {
                    CityId = city.IdCity,
                    Longitude = city.Longitude.ToString(),
                    Latitude = city.Latitude.ToString()
                };
            }

            return new LocationItem();
        }
    }
}