using System;

namespace MS.CommandQuery.Core.Model
{
    public class ContentDetails
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public int LanguageId { get; set; }

        public string UserName { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
