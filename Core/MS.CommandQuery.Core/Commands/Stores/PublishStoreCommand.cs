using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{
    public class PublishStoreCommand : ICommand
    {
        public int IdStore { get; set; }

        public bool IsPublished { get; set; }

        public bool IsRevised { get; set; }
    }
}
