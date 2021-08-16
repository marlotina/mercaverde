using System.Linq;
using System.Web.Http;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.News;
using MS.Utils;
using MS.Web.Models;

namespace MS.Web.Controllers
{
    public class NewsServiceController : ApiController
    {
        private readonly INewsWebQueryReposiroty _newsWebQueryReposiroty;

        public NewsServiceController(INewsWebQueryReposiroty newsWebQueryReposiroty)
        {
            _newsWebQueryReposiroty = newsWebQueryReposiroty;
        }

        [HttpPost]
        [Route("api/News/List/")]
        public NewsListItems List(Search.PaginationFilter filter)
        {
            var listNews = _newsWebQueryReposiroty.GetNews(filter.StartItem, filter.NumItems, filter.LanguageId);


            return listNews;
        }
    }
}
