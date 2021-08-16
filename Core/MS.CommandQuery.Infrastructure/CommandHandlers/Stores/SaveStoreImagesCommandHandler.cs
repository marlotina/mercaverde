using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class SaveStoreImagesCommandHandler : ICommandHandler<SaveStoreImagesCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreImagesCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (SaveStoreImagesCommand)commandObj;

                var storeImage = new StoreImage();
                if (command.IdStoreImage > 0)
                {
                    storeImage = _context.StoreImage.FirstOrDefault(i => i.IdStoreImage == command.IdStoreImage);

                }

                if (storeImage == null || storeImage.IdStoreImage == 0)
                {
                    storeImage = new StoreImage();
                    storeImage.Order = _context.StoreImage.Count(i => i.StoreId == command.StoreId) + 1;
                    storeImage.Store = _context.Store.FirstOrDefault(p => p.IdStore == command.StoreId);
                    storeImage.StoreId = command.StoreId;
                }
                else
                {
                    storeImage.Order = command.Order;
                    storeImage.IsMain = command.IsMain;
                }

                storeImage.Url = command.ImageUrlList;

                _context.StoreImage.Add(storeImage);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("SaveStoreImagesCommandHandler", ex.Message);
            }
        }
    }
}
