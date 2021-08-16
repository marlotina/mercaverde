using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MS.CommandQuery.Core.Queries.Common
{
    public interface ICategoriesQueryReposiroty
    {
        List<ListItem> GetCategoriesListByLanguage(int languageId);
    }
}
