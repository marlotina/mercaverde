using System;
using System.Linq;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Events;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Events
{
    public class EventsWebQueryReposiroty : QueryBase, IEventsWebQueryReposiroty
    {
        public EventsWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public Event GetEventById(int eventId)
        {
            var eventItem = Context.Event.FirstOrDefault(n => n.IdEvent == eventId);

            return eventItem;
        }

        public EventListItem GetEvents(DateTime date)
        {
            var eventList = new EventListItem();

            const string query = "EXEC spEventsWebSearchList @startDate = '{0}', @endDate = '{1}'";

            var qlQuery = string.Format(query, date.ToString("yyyy-MM-dd"), date.AddMonths(1).ToString("yyyy-MM-dd"));
            eventList.ListEvents = Context.Database.SqlQuery<EventItem>(qlQuery);
            
            return eventList;
        }
    }
}
