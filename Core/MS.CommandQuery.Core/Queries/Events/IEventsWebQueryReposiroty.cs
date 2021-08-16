using System;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Events
{
    public interface IEventsWebQueryReposiroty
    {
        Event GetEventById(int eventId);

        EventListItem GetEvents(DateTime date);
    }
}
