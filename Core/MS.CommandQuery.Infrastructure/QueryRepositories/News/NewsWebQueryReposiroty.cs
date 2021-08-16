using System.Linq;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.News;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.Utils;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.News
{
    public class NewsWebQueryReposiroty : QueryBase, INewsWebQueryReposiroty
    {
        public NewsWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public NewsItem GetNewsById(int newsId)
        {
            var news = Context.News.FirstOrDefault(n => n.IdNews == newsId);

            return news;
        }

        public NewsListItems GetNews(int startItem, int numItems, int languageId)
        {
            var newsList = new NewsListItems();
            const string query = "EXEC spNewsWebSearchList @startItem = {0},  @numItems = {1}";

            var qlQuery = string.Format(query, startItem, numItems);
            newsList.ListNews = Context.Database.SqlQuery<NewsWebItem>(qlQuery).ToList();
            newsList.NumItems = numItems;
            newsList.StartItem = startItem;

            foreach (var news in newsList.ListNews.ToList())
            {
                news.Url = UrlHelper.GetNewsUrl(news.IdItem, languageId);
            }


            if (newsList.ListNews.Any())
                newsList.TotalItems = newsList.ListNews.FirstOrDefault().TotalItems;

            return newsList;
        }
    }
}
