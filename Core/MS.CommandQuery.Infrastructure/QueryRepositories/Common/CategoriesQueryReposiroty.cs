using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Common
{
    public class CategoriesQueryReposiroty : QueryBase, ICategoriesQueryReposiroty
    {
        public CategoriesQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public List<ListItem> GetCategoriesListByLanguage(int languageId)
        {
            var result = new List<ListItem>();

            foreach (var categoryTranslation in Context.CategoryLanguage.Where(c => c.LanguageId == languageId))
            {
                result.Add(new ListItem() { Value = categoryTranslation.CategoryId.ToString(), Text = categoryTranslation.Description });
            }

            return result;
        }
    }
}