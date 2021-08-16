using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Posts
{
    public class DeletePostCommand : ICommand
    {
        public int IdPost { get; set; }
    }
}
