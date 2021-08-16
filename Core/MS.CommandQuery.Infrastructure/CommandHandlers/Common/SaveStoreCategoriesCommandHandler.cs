using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Common
{
    public class SaveStoreCategoriesCommandHandler : ICommandHandler<SaveStoreCategoriesCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreCategoriesCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveStoreCategoriesCommand)commandObj;

            var store = _context.Store.FirstOrDefault(s => s.IdStore == command.IdStore);
            if (store != null)
            {
                var storeCategories = store.Categories;

                foreach (var category in storeCategories.ToList())
                {
                    if (!command.CategoryList.Contains(category.IdCategory))
                    {
                        storeCategories.Remove(category);
                    }
                }

                foreach (var category in command.CategoryList)
                {
                    if (storeCategories.All(l => l.IdCategory != category))
                    {
                        storeCategories.Add(_context.Category.FirstOrDefault(c => c.IdCategory == category));
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}
