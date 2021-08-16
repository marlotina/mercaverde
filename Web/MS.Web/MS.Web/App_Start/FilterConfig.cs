using System.Web.Mvc;
using MS.Web.AppCode;

namespace MS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("es"), 0);
        }
    }
}
