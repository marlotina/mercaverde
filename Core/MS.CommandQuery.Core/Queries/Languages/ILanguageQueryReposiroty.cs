using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MS.CommandQuery.Core.Queries.Languages
{
    public interface ILanguageQueryReposiroty
    {
        List<ListItem> GetLanguagesComboByLanguageId();
    }
}
