using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class PublishStoreCommandHandler : ICommandHandler<PublishStoreCommand>
    {
        private readonly IMsContext _context;

        public PublishStoreCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (PublishStoreCommand)commandObj;

                var store = new Store();

                if (command.IdStore != 0)
                {
                    store = _context.Store.FirstOrDefault(p => p.IdStore == command.IdStore);
                }

                if (store != null)
                {
                    store.IsPublished = command.IsPublished;
                    if (command.IsPublished)
                    {
                        store.PublishDate = DateTime.Now;
                    }

                    store.IsRevised = command.IsRevised;

                    if (command.IsRevised)
                    {
                        store.RevisedDate = DateTime.Now;
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new CommandException("DeleteStoreCommandHandler", ex.Message);
            }
        }
    }
}
