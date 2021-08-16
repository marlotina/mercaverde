using System.Runtime.InteropServices.ComTypes;
using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{
    public class SaveStoreImagesCommand : ICommand
    {
        public int IdStoreImage { get; set; }
        
        public int StoreId { get; set; }

        public string ImageUrlList { get; set; }
 
        public int Order { get; set; } 

        public bool IsMain { get; set; }

        public int Action { get; set; }
    }
}