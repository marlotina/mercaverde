using System.Web.Mvc;
using MS.CommandQuery.Core.Queries.Events;
using MS.Web.Base;

namespace MS.Web.Controllers
{
    public class EventsController : CustomController
    {
        public IEventsWebQueryReposiroty _eventsWebQueryReposiroty { get; set; }

        public EventsController(IEventsWebQueryReposiroty eventsWebQueryReposiroty)
        {
            _eventsWebQueryReposiroty = eventsWebQueryReposiroty;
        }
        // GET: Event
        public ActionResult EventList()
        {
            Load();
            ViewData["IdLanguage"] = LanguageId;
            return View();
        }

        public ActionResult EventDetail()
        {
            Load();
            int newsId = 0;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["eventId"]))
            {
                newsId = int.Parse(HttpContext.Request.QueryString["eventId"]);
            }

            var newsItem = _eventsWebQueryReposiroty.GetEventById(newsId);

            return View("EventDetail", newsItem);
        }
    }
}