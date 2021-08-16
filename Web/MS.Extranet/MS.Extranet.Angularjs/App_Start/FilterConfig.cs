using System.Web.Mvc;
using MS.Extranet.Angularjs.App_Start;

namespace MS.Extranet.Angularjs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CultureFilter(defaultCulture: "es"));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
