using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MS.Utils;

namespace MS.Extranet.Angularjs.App_Start
{
    public class CultureFilter : IAuthorizationFilter
    {
        private readonly string defaultCulture;

        public CultureFilter(string defaultCulture)
        {
            this.defaultCulture = defaultCulture;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var values = filterContext.RouteData.Values;

            string culture = (string)values["culture"] ?? this.defaultCulture;

            string cultureCode = LanguageHelper.GetCultureCodeBySortName(culture);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode); 
        }
    }
}