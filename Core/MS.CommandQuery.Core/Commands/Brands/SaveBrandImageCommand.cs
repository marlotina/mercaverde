using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Brands
{
    public class SaveBrandImagesCommand : ICommand
    {
        public int IdBrandImage { get; set; }

        public int BrandId { get; set; }

        public string ImageUrl { get; set; }
 
        public int Order { get; set; } 

        public bool IsMain { get; set; } 
    }
}