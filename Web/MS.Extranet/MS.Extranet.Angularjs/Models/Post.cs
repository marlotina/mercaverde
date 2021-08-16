namespace MS.Extranet.Angularjs.Models
{
    public class Posts
    {
        public class Post
        {
            public int IdPost { get; set; }

            public string Title { get; set; }

            public string Text { get; set; }
            
            public int? LanguageId { get; set; }

            public int UserId { get; set; }

            public bool HasRevised { get; set; }

            public bool IsPublished { get; set; }

            public string LastActivity { get; set; }
        }
    }
}