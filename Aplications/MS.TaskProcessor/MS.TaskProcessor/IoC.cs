using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Core.Queries.Users;
using MS.CommandQuery.Infrastructure.CommandHandlers;
using MS.CommandQuery.Infrastructure.CommandHandlers.Tasks;
using MS.CommandQuery.Infrastructure.CommandHandlers.Users;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.CommandQuery.Infrastructure.QueryRepositories.Common;
using MS.CommandQuery.Infrastructure.QueryRepositories.Mails;
using MS.CommandQuery.Infrastructure.QueryRepositories.Users;
using StructureMap;
using StructureMap.Graph;

namespace MS.TaskProcessor
{
    /// <summary>
    /// See http://stackoverflow.com/questions/6777671/setting-up-structure-map-in-a-c-sharp-console-application
    /// </summary>
    public class IoC
    {
        public static void InitIoC()
        {
            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();

                    scan.AssemblyContainingType<UpdateTaskProcessCommandHandler>();
                    scan.IncludeNamespaceContainingType<UpdateTaskProcessCommandHandler>();

                    scan.AssemblyContainingType<ModifyUserCommandHandler>();
                    scan.IncludeNamespaceContainingType<ModifyUserCommandHandler>();
                    
                    scan.AddAllTypesOf(typeof(ICommandHandler<>));
                });

                config.For<IMsContext>().Use<MsContext>();
                config.For<ITaskProcessQueryReposiroty>().Use<TaskProcessQueryReposiroty>();
                config.For<IUserQueryReposiroty>().Use<UserQueryReposiroty>();
                config.For<IMailTemplateQueryRepository>().Use<MailTemplateQueryRepository>();
                config.For<ICommandExecutor>().Use<CommandExecutor>();
                config.For<ICommandDispatcher>().Use<CommandDispatcher>();
            });
        }
    }
}
