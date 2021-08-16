using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace MS.Web.AppCode
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "es";

        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["culture"] ?? _DefaultLanguage;
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);    
            
        }
    }
}
