using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Brands
{
    public class SaveBrandDescriptionCommandHandler : ICommandHandler<SaveBrandDescriptionCommand>
    {
        private readonly IMsContext _context;

        public SaveBrandDescriptionCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveBrandDescriptionCommand)commandObj;

            var description = new BrandDescription();
            if (command.BrandId > 0 && command.LanguageId > 0)
            {
                description = _context.BrandDescription.FirstOrDefault(d => d.LanguageId == command.LanguageId && d.BrandId == command.BrandId);
            }

            if (description == null)
            {
                description = new BrandDescription();
            }

            description.Brand = _context.Brand.FirstOrDefault(b => b.IdBrand == command.BrandId);
            description.Language = _context.Language.FirstOrDefault(p => p.IdLanguage== command.LanguageId);
            
            description.Description = command.Description;
            description.Title = command.Title;

            _context.BrandDescription.Add(description);
        }
    }
}
