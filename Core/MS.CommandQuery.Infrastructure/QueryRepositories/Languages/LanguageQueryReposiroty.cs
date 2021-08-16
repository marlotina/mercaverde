using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Languages;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Languages
{
    public class LanguageQueryReposiroty : QueryBase, ILanguageQueryReposiroty
    {
        public LanguageQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public List<ListItem> GetLanguagesComboByLanguageId()
        {
            var languageList = from l in Context.Language
                select new ListItem() {Value = l.IdLanguage.ToString(), Text = l.Name};

            return languageList.ToList();
        }
    }
}
