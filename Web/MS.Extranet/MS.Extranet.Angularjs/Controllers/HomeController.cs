using System.Web.Mvc;
using MS.Extranet.Angularjs.Base;

namespace MS.Extranet.Angularjs.Controllers
{
    public class HomeController : CustomController
    {
        [Authorize]
        public ActionResult Index()
        {
            Load();
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            Load();
            return View();
        }

        [Authorize]
        public ActionResult Owner()
        {
            Load();
            return View();
        }

        [Authorize]
        public ActionResult Legal()
        {
            Load();
            return View();
        }
    }
}