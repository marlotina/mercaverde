// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Web.Routing;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Languages;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Core.Queries.Posts;
using MS.CommandQuery.Core.Queries.Stores;
using MS.CommandQuery.Core.Queries.Users;
using MS.CommandQuery.Infrastructure.CommandHandlers;
using MS.CommandQuery.Infrastructure.CommandHandlers.Common;
using MS.CommandQuery.Infrastructure.CommandHandlers.Posts;
using MS.CommandQuery.Infrastructure.CommandHandlers.Stores;
using MS.CommandQuery.Infrastructure.CommandHandlers.Users;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.CommandQuery.Infrastructure.QueryRepositories.Common;
using MS.CommandQuery.Infrastructure.QueryRepositories.Languages;
using MS.CommandQuery.Infrastructure.QueryRepositories.Locations;
using MS.CommandQuery.Infrastructure.QueryRepositories.Mails;
using MS.CommandQuery.Infrastructure.QueryRepositories.Posts;
using MS.CommandQuery.Infrastructure.QueryRepositories.Stores;
using MS.CommandQuery.Infrastructure.QueryRepositories.Users;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Web;

namespace MS.Extranet.Angularjs.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();

                    //Add the assemblies that contains the handlers and validators to the scanning
                    scan.AssemblyContainingType<AddUserCommandHandler>();
                    scan.IncludeNamespaceContainingType<AddUserCommandHandler>();
                    //scan.AssemblyContainingType<AddUserCommandValidator>();
                    //scan.IncludeNamespaceContainingType<AddUserCommandValidator>();

                    scan.AssemblyContainingType<SavePostCommandHandler>();
                    scan.IncludeNamespaceContainingType<SavePostCommandHandler>();

                    scan.AssemblyContainingType<SaveStoreCommandHandler>();
                    scan.IncludeNamespaceContainingType<SaveStoreCommandHandler>();

                    scan.AssemblyContainingType<ModifyUserCommandHandler>();
                    scan.IncludeNamespaceContainingType<ModifyUserCommandHandler>();

                    //Add the assemblies that contains the handlers and validators to the scanning
                    scan.AssemblyContainingType<SaveStoreCategoriesCommandHandler>();
                    scan.IncludeNamespaceContainingType<SaveStoreCategoriesCommandHandler>();


                    //Add the assemblies that contains the handlers and validators to the scanning
                    scan.AssemblyContainingType<SaveStoreLabelsCommandHandler>();
                    scan.IncludeNamespaceContainingType<SaveStoreLabelsCommandHandler>();


                    //Add the assemblies that contains the handlers and validators to the scanning
                    scan.AssemblyContainingType<RecoverPasswordCommandHandler>();
                    scan.IncludeNamespaceContainingType<RecoverPasswordCommandHandler>();

                    scan.AssemblyContainingType<DeletePostCommandHandler>();
                    scan.IncludeNamespaceContainingType<DeletePostCommandHandler>();

                    scan.AssemblyContainingType<PublishStoreCommandHandler>();
                    scan.IncludeNamespaceContainingType<PublishStoreCommandHandler>();

                    scan.AssemblyContainingType<SaveSuggestingCommandHandler>();
                    scan.IncludeNamespaceContainingType<SaveSuggestingCommandHandler>();
                    

                    //Register all types of command validators and handlers
                    scan.AddAllTypesOf(typeof(ICommandHandler<>));
                    //scan.AddAllTypesOf(typeof(ICommandValidator<>));
                });

                //The context needs to be one instance per http request
                x.For<IMsContext>().HttpContextScoped().Use<MsContext>();
                x.For<IUserQueryReposiroty>().Use<UserQueryReposiroty>();
                x.For<ICommandExecutor>().Use<CommandExecutor>();
                x.For<ICommandDispatcher>().Use<CommandDispatcher>();
                x.For<ILocationQueryReposiroty>().Use<LocationQueryReposiroty>();
                x.For<IPostQueryReposiroty>().Use<PostQueryReposiroty>();
                x.For<IStoreQueryReposiroty>().Use<StoreQueryReposiroty>();
                //x.For<IBrandQueryReposiroty>().Use<BrandQueryReposiroty>();
                x.For<ILanguageQueryReposiroty>().Use<LanguageQueryReposiroty>();
                x.For<ILabelsQueryReposiroty>().Use<LabelsQueryReposiroty>();
                x.For<ICategoriesQueryReposiroty>().Use<CategoriesQueryReposiroty>();
                x.For<IMailTemplateQueryRepository>().Use<MailTemplateQueryRepository>();
                x.For<RequestContext>().Use(ctx => HttpContext.Current.Request.RequestContext);
            });
            return ObjectFactory.Container;
        }
        //public static IContainer Initialize() {
        //    return new Container(c => c.AddRegistry<DefaultRegistry>());
        //}
    }
}