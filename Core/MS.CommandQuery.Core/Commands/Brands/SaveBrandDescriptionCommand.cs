using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Brands
{
    public class SaveBrandDescriptionCommand : ICommand
    {
        public int BrandId { get; set; }

        public int LanguageId { get; set; }
 
        public string Title { get; set; } 

        public string Description { get; set; } 
    }
}