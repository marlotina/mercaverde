using System;
using System.Collections.Generic;

namespace MS.CommandQuery.Core.Model
{
    public class NewsListItems : BaseSearchItem
    {
        public IEnumerable<NewsWebItem> ListNews { get; set; } 
    }

    public class NewsWebItem
    {
        public int IdItem { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }
        
        public int LanguageId { get; set; }

        public DateTime PublishDate { get; set; }

        public int TotalItems { get; set; }

        public string Url { get; set; }
    }
}
