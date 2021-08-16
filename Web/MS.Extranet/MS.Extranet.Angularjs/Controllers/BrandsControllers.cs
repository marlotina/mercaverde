using System.Web.Mvc;
using MS.Extranet.Angularjs.Base;

namespace MS.Extranet.Angularjs.Controllers
{
    public class BrandsController : CustomController
    {
        [Authorize]
        public ActionResult SaveBrand()
        {
            Load();
            ViewData["IdBrand"] = CurrentUser.IdBrand;

            return View();
        }

        [Authorize]
        public ActionResult ListBrands()
        {
            return View();
        }
    }
}