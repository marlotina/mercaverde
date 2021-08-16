using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Common
{
    public class LabelsWebQueryReposiroty : QueryBase, ILabelsWebQueryReposiroty
    {
        public LabelsWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public IEnumerable<CategoryItem> GetLabelsListByLanguage(int languageId)
        {
            const string query = "EXEC spGetLabelsForWeb @languageId = {0}";
            var qlQuery = string.Format(query, languageId);
            var labelList = Context.Database.SqlQuery<CategoryItem>(qlQuery);

            return labelList;
        }
    }
}