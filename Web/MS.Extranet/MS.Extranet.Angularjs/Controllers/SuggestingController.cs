using System.Web.Mvc;
using MS.Extranet.Angularjs.Base;

namespace MS.Extranet.Angularjs.Controllers
{
    public class SuggestingController : CustomController
    {
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            Load();
            return View();
        }
    }
}