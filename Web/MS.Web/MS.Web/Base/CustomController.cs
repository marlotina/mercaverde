using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MS.Web.Base
{
    public class CustomController : Controller
    {
        public CustomController()
        {
            
        }
        public int LanguageId { get; set; }

        public string LanguageUrl { get; set; }

        public void Load()
        {
            GetLanguage();
        }

        private void GetLanguage()
        {
            var routeCulture = "es";
            if (HttpContext.Request.RequestContext.RouteData.Values["culture"] != null)
            {
                routeCulture = HttpContext.Request.RequestContext.RouteData.Values["culture"].ToString();
                LanguageId = Utils.LanguageHelper.GetLanguageIdFromUrlCulture(routeCulture);
                CreateCookieLanguage(routeCulture);
            }
            else
            {
                HttpCookie cookie = Request.Cookies["_culture"];
                if (cookie != null)
                {
                    routeCulture = cookie.Value;
                }
            }

            ViewData["LanguageCode"] = routeCulture;
            LanguageId = Utils.LanguageHelper.GetLanguageIdFromUrlCulture(routeCulture);
        }

        private void CreateCookieLanguage(string culture)
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = culture, Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);
        }
    }
}