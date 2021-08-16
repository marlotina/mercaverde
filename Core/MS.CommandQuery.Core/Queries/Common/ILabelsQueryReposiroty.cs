using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MS.CommandQuery.Core.Queries.Common
{
    public interface ILabelsQueryReposiroty
    {
        List<ListItem> GetLabelsListByLanguage(int languageId);
    }
}
