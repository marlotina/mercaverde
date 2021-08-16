using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class SaveStoreImagesOrderCommandHandler : ICommandHandler<SaveStoreImagesOrderCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreImagesOrderCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (SaveStoreImagesOrderCommand)commandObj;

                for (int i = 0; i < command.Order.Count(); i++)
                {
                    var idStoreImage = int.Parse(command.Order[i]);
                    var firstOrDefault = _context.StoreImage.FirstOrDefault(s => s.IdStoreImage == idStoreImage);
                    if (firstOrDefault != null && firstOrDefault.Order != i + 1)
                        firstOrDefault.Order = i + 1;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("SaveStoreImagesCommandHandler", ex.Message);
            }
        }
    }
}
