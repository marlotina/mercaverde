using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Brands
{
    public class SaveBrandImagesCommandHandler : ICommandHandler<SaveBrandImagesCommand>
    {
        private readonly IMsContext _context;

        public SaveBrandImagesCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveBrandImagesCommand)commandObj;

            var storeImage = new StoreImage();
            if (command.IdBrandImage > 0)
            {
                storeImage = _context.StoreImage.FirstOrDefault(i => i.IdStoreImage == command.IdBrandImage);
            }

            if (storeImage == null || storeImage.IdStoreImage == 0)
            {
                storeImage = new StoreImage();
            }

            storeImage.Store = _context.Store.FirstOrDefault(p => p.IdStore == command.BrandId);
            storeImage.Order = command.Order;
            storeImage.IsMain = command.IsMain;
            storeImage.Url = command.ImageUrl;

            _context.StoreImage.Add(storeImage);
        }
    }
}
