using System;
using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Brands
{
    public class SaveBrandCommandHandler : ICommandHandler<SaveBrandCommand>
    {
        private readonly IMsContext _context;

        public SaveBrandCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveBrandCommand)commandObj;

            var brand = new Brand();

            if (command.IdBrand != 0)
            {
                brand = _context.Brand.FirstOrDefault(b => b.IdBrand == command.IdBrand);
            }

            if (brand == null || brand.IdBrand == 0)
            {
                brand = new Brand { CreationDate = DateTime.Now };
            }
            
            brand.Email = command.Email;
            brand.LastActivity = DateTime.Now;
            brand.Street = command.Street;
            brand.Number = command.Number;
            brand.PostalCode = command.PostalCode;
            brand.Phone = command.Phone;
            brand.PrefixPhone = command.PrefixPhone;
            brand.Published = command.IsPublished;

            if (command.UserId > 0)
            {
                brand.User = _context.User.FirstOrDefault(u => u.IdUser == command.UserId);
            }

            if (command.CityId > 0)
            {
                brand.City = _context.City.FirstOrDefault(c => c.IdCity == command.CityId);
            }

            if (command.DistrictId > 0)
            {
                brand.District = _context.District.FirstOrDefault(d => d.IdDistrict == command.DistrictId);
            }

            if (brand.IdBrand == 0)
            {
                _context.Brand.Add(brand);    
            }
            else
            {
                _context.SaveChanges();
            }
        }
    }
}
