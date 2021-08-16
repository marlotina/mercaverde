using System;
using System.Collections.Generic;

namespace MS.CommandQuery.Core.Model
{
    public class EventListItem
    {
        public IEnumerable<EventItem> ListEvents { get; set; } 
    }

    public class EventItem
    {
        public int IdEvent { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public string Url { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int LanguageId { get; set; }

        public DateTime? PublishDate { get; set; }

        public int TotalItems { get; set; }
    }
}
