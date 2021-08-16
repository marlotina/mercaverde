using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{ 
    public class DeleteStoreCommand :ICommand
    {
        public int IdStore { get; set; }
    }
}