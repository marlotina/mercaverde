using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Common
{
    public class LabelsQueryReposiroty : QueryBase, ILabelsQueryReposiroty
    {
        public LabelsQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public List<ListItem> GetLabelsListByLanguage(int languageId)
        {
            var result = new List<ListItem>();

            foreach (var labelTranslation in Context.LabelLanguage.Where(c => c.LanguageId == languageId))
            {
                result.Add(new ListItem() { Value = labelTranslation.LabelId.ToString(), Text = labelTranslation.Description });
            }

            return result;
        }
    }
}