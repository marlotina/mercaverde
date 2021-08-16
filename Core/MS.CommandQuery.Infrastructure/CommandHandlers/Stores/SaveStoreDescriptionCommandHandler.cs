using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class SaveStoreDescriptionCommandHandler : ICommandHandler<SaveStoreDescriptionCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreDescriptionCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (SaveStoreDescriptionCommand)commandObj;
                var isNew = false;
                var description = new StoreDescription();
                if (command.StoreId > 0 && command.LanguageId > 0)
                {
                    description = _context.StoreDescription.FirstOrDefault(d => d.LanguageId == command.LanguageId && d.StoreId == command.StoreId);
                }

                if (description == null)
                {
                    description = new StoreDescription();
                    isNew = true;
                }

                description.Store = _context.Store.FirstOrDefault(p => p.IdStore == command.StoreId);
                description.Language = _context.Language.FirstOrDefault(p => p.IdLanguage == command.LanguageId);

                description.Description = command.Description;
                description.ShortDescription = command.ShortDescription;
                description.Title = command.Title;

                if (isNew)
                {
                    _context.StoreDescription.Add(description);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("SaveStoreDescriptionCommandHandler", ex.Message);
            }
            
        }
    }
}
