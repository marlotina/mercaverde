using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class DeleteStoreCommandHandler : ICommandHandler<DeleteStoreCommand>
    {
        private readonly IMsContext _context;

        public DeleteStoreCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (DeleteStoreCommand)commandObj;

                var store = new Store();

                if (command.IdStore != 0)
                {
                    store = _context.Store.FirstOrDefault(p => p.IdStore == command.IdStore);
                }
                if (store != null)
                {
                    if (!store.IsPublished)
                    {
                        store.Deleted = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new CommandException("PropertyIsPublished", "##PropertyIsPublished##");
                    }    
                }
            }
            catch (Exception ex)
            {
                throw new CommandException("DeleteStoreCommandHandler", ex.Message);
            }
        }
    }
}
