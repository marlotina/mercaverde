using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{
    public class SaveStoreImagesOrderCommand : ICommand
    {
        public int IdStore { get; set; }

        public string[] Order { get; set; }
    }
}