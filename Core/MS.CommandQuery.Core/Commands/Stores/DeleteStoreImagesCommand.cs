using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{
    public class DeleteStoreImagesCommand : ICommand
    {
        public int IdStoreImage { get; set; }
    }
}