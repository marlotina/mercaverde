// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

using System.Web;
using System.Web.Routing;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Events;
using MS.CommandQuery.Core.Queries.Languages;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Core.Queries.News;
using MS.CommandQuery.Core.Queries.Posts;
using MS.CommandQuery.Core.Queries.Search;
using MS.CommandQuery.Core.Queries.Stores;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.CommandQuery.Infrastructure.QueryRepositories.Common;
using MS.CommandQuery.Infrastructure.QueryRepositories.Events;
using MS.CommandQuery.Infrastructure.QueryRepositories.Languages;
using MS.CommandQuery.Infrastructure.QueryRepositories.Locations;
using MS.CommandQuery.Infrastructure.QueryRepositories.News;
using MS.CommandQuery.Infrastructure.QueryRepositories.Posts;
using MS.CommandQuery.Infrastructure.QueryRepositories.Search;
using MS.CommandQuery.Infrastructure.QueryRepositories.Stores;
using StructureMap;
using StructureMap.Web;

namespace MS.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                //x.Scan(scan =>
                //{
                //    scan.AssembliesFromApplicationBaseDirectory();
                //    scan.WithDefaultConventions();

                //    //Add the assemblies that contains the handlers and validators to the scanning
                //    //scan.AssemblyContainingType<AddUserCommandHandler>();
                //    //scan.IncludeNamespaceContainingType<AddUserCommandHandler>();
                    
                //    //Register all types of command validators and handlers
                //    //scan.AddAllTypesOf(typeof(ICommandHandler<>));
                //    //scan.AddAllTypesOf(typeof(ICommandValidator<>));
                //});

                //The context needs to be one instance per http request
                x.For<IMsContext>().HttpContextScoped().Use<MsContext>();
                //x.For<ICommandExecutor>().Use<CommandExecutor>();
                //x.For<ICommandDispatcher>().Use<CommandDispatcher>();
                x.For<ILocationWebQueryReposiroty>().Use<LocationWebQueryReposiroty>();
                x.For<ISearchWebQueryReposiroty>().Use<SearchWebQueryReposiroty>();
                x.For<ILanguageQueryReposiroty>().Use<LanguageQueryReposiroty>();
                x.For<INewsWebQueryReposiroty>().Use<NewsWebQueryReposiroty>();
                x.For<IEventsWebQueryReposiroty>().Use<EventsWebQueryReposiroty>();
                x.For<IPostsWebQueryReposiroty>().Use<PostsWebQueryReposiroty>();
                x.For<ICategoriesWebQueryReposiroty>().Use<CategoriesWebQueryReposiroty>();
                x.For<IStoreWebQueryReposiroty>().Use<StoreWebQueryReposiroty>();
                x.For<ILabelsWebQueryReposiroty>().Use<LabelsWebQueryReposiroty>();    
                
                x.For<RequestContext>().Use(ctx => HttpContext.Current.Request.RequestContext);
            });
            return ObjectFactory.Container;
        }
        //public static IContainer Initialize() {
        //    return new Container(c => c.AddRegistry<DefaultRegistry>());
        //}
    }
}