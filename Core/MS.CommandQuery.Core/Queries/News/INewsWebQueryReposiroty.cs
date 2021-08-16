using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.News
{
    public interface INewsWebQueryReposiroty
    {
        NewsItem GetNewsById(int newsId);

        NewsListItems GetNews(int startItem, int numItems, int languageId);
    }
}
