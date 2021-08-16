using System.Collections.Generic;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Common
{
    public interface ICategoriesWebQueryReposiroty
    {
        IEnumerable<CategoryItem> GetCategoriesListByLanguage(int languageId);
    }
}
