using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Stores
{
    public class SaveStoreCommandHandler : ICommandHandler<SaveStoreCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (SaveStoreCommand)commandObj;

                var store = new Store();

                if (command.IdStore != 0)
                {
                    store = _context.Store.FirstOrDefault(p => p.IdStore == command.IdStore);
                }

                if (store == null || store.IdStore == 0)
                {
                    store = new Store
                    {
                        CreationDate = DateTime.Now,
                        IsRevised = false
                    
                    };
                }

                //Carrer del Rosselló, 180, Barcelona, España
                var completeStreet = command.StreetComplete.Split(',');

                store.Email = command.Email;
                store.Name = command.Name;
                store.LastActivity = DateTime.Now;

                store.StreetComplete = command.StreetComplete;
                store.PostalCode = command.PostalCode;
                if (completeStreet.Any())
                {
                    store.Street = completeStreet[0];
                    store.Number = completeStreet[1];
                }

                store.Phone = command.Phone;
                store.PrefixPhone = command.PrefixPhone;
                store.MobilePhone = command.MobilePhone;

                store.TimeTable = command.TimeTable;
                store.IsPublished = command.IsPublished;
                store.Longitude = command.Longitude;
                store.Latitude = command.Latitude;
                store.UrlWebSite = command.UrlWebSite;

                store.CityId = command.CityId;

                if (command.DistrictId > 0)
                {
                    store.DistrictId = command.DistrictId;
                }

                store.UserId = command.UserId;


                if (store.IdStore == 0)
                {
                    _context.Store.Add(store);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("SaveStoreCommandHandler", ex.Message);
            }
        }
    }
}
