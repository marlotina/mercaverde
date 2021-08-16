using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Posts
{
    public class SavePostCommand : ICommand
    {
        public int IdPost { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }

        public int? LanguageId { get; set; }

        public int UserId { get; set; }
    }
}
