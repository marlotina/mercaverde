using System.Web.Mvc;
using MS.CommandQuery.Core.Queries.News;
using MS.Web.Base;

namespace MS.Web.Controllers
{
    public class NewsController : CustomController
    {
        public INewsWebQueryReposiroty _newsWebQueryReposiroty { get; set; }

        public NewsController(INewsWebQueryReposiroty newsWebQueryReposiroty)
        {
            _newsWebQueryReposiroty = newsWebQueryReposiroty;
        }
        // GET: News
        public ActionResult NewsList()
        {
            Load();
            ViewData["IdLanguage"] = LanguageId;
            return View();
        }

        public ActionResult NewsDetail()
        {
            Load();
            int newsId = 0;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["newsId"]))
            {
                newsId = int.Parse(HttpContext.Request.QueryString["newsId"]);
            }

            var newsItem = _newsWebQueryReposiroty.GetNewsById(newsId);

            return View("NewsDetail", newsItem);
        }
    }
}