using System.Collections.Generic;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Common
{
    public interface ILabelsWebQueryReposiroty
    {
        IEnumerable<CategoryItem> GetLabelsListByLanguage(int languageId);
    }
}
