using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories
{
    public abstract class QueryBase
    {
        protected readonly IMsContext Context;

        protected QueryBase(IMsContext context)
        {
            Context = context;
        }
    }
}
