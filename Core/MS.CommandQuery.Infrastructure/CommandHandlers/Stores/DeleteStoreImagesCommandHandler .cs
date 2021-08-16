using System;
using System.IO;
using System.Linq;
using System.Web;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.CommandQuery.Core;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class DeleteStoreImagesCommandHandler : ICommandHandler<DeleteStoreImagesCommand>
    {
        private readonly IMsContext _context;

        public DeleteStoreImagesCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (DeleteStoreImagesCommand)commandObj;
                var image = _context.StoreImage.FirstOrDefault(i => i.IdStoreImage == command.IdStoreImage);

                if (image != null)
                {
                    var fileSavePath = HttpContext.Current.Server.MapPath(image.Url);

                    if (File.Exists(fileSavePath))
                    {
                         File.Delete(fileSavePath);

                        _context.StoreImage.Remove(image);
                        _context.SaveChanges();
                    }
                }         
            }
            catch (Exception ex)
            {
                throw new CommandException("DeleteStoreImagesCommandHandler", ex.Message);
            }
        }
    }
}
