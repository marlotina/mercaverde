using System.Collections.Generic;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Locations
{
    public interface ILocationWebQueryReposiroty
    {
        List<ListItem> GetDistrictsForFilter();

        List<ListItem> GetCitiesForComboByLanguage(int languageId, int countryId);

        LocationItem GetCityById(int cityId);
    }
}
