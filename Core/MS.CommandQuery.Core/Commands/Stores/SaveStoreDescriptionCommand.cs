using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Stores
{
    public class SaveStoreDescriptionCommand : ICommand
    {
        public int StoreId { get; set; }

        public int LanguageId { get; set; }
 
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; } 
    }
}