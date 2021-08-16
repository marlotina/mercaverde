using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Common
{
    public class SaveSuggestingCommand : ICommand
    {
        public int UserId { get; set; }

        public string Text { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

    }
}
