using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MS.CommandQuery.Core.Queries.Locations
{
    public interface ILocationQueryReposiroty
    {
        List<ListItem> GetCitiesForComboByLanguage(int languageId, int countryId);

        List<ListItem> GetCountriesForComboByLanguage(int languageId);

        List<ListItem> GetDistrictsForCombo();
    }
}
