using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.Commands
{
    public abstract class CommandBase
    {
        protected readonly ISampleDbContext Context;

        protected CommandBase(ISampleDbContext context)
        {
            Context = context;
        }
    }
}
