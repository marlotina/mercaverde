using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MS.Extranet.Angularjs.DependencyResolution;
using StructureMap;

namespace MS.Extranet.Angularjs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //StructureMap Container
            IContainer container = IoC.Initialize();

            //Register for MVC
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));



            //Register for Web API
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        //private void Application_BeginRequest(Object source, EventArgs e)
        //{
        //    HttpApplication application = (HttpApplication)source;
        //    HttpContext context = application.Context;

        //    string culture = null;
        //    if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
        //    {
        //        culture = Request.UserLanguages[0];
        //        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
        //        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        //    }
        //}
    }
}
