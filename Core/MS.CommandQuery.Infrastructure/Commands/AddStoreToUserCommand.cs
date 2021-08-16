using System;
using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Commands;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.Commands
{
    public class AddStoreToUserCommand : CommandBase, IAddStoreToUserCommand
    {
        public AddStoreToUserCommand(ISampleDbContext context) : base(context)
        {
        }

        public void Add(User user, IEnumerable<Store> stores)
        {
            if(user == null)
                throw new ArgumentNullException("user");

            if(stores == null)
                throw new ArgumentNullException("departments");

            if(!stores.Any())
                throw new ArgumentException("departments");
            
            Context.SaveChanges();
        }
    }
}
