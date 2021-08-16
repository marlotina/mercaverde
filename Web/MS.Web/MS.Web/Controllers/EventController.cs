using System;
using System.Web.Http;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Events;

namespace MS.Web.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventsWebQueryReposiroty _eventsWebQueryReposiroty;

        public EventController(IEventsWebQueryReposiroty eventsWebQueryReposiroty)
        {
            _eventsWebQueryReposiroty = eventsWebQueryReposiroty;
        }

        [HttpPost]
        [Route("api/Events/List/{date}")]
        public EventListItem List(string date)
        {
            var currentDate = !string.IsNullOrEmpty(date) ? DateTime.Parse(date) : DateTime.Now;
            var listEvents = _eventsWebQueryReposiroty.GetEvents(currentDate);

            return listEvents;
        }
    }
}
