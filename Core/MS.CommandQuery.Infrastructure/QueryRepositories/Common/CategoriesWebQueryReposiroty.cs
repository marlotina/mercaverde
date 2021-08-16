using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Common
{
    public class CategoriesWebQueryReposiroty : QueryBase, ICategoriesWebQueryReposiroty
    {
        public CategoriesWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public IEnumerable<CategoryItem> GetCategoriesListByLanguage(int languageId)
        {
            const string query = "EXEC spGetCategoriesForWeb @languageId = {0}";
            var qlQuery = string.Format(query, languageId);
            var categoryList = Context.Database.SqlQuery<CategoryItem>(qlQuery);

            return categoryList;
        }
    }
}