using System.Web.Mvc;
using MS.CommandQuery.Core.Queries.Stores;
using MS.Web.Base;

namespace MS.Web.Controllers
{
    public class StoresController : CustomController
    {
        public IStoreWebQueryReposiroty _storeWebQueryReposiroty { get; set; }

        public StoresController(IStoreWebQueryReposiroty storeWebQueryReposiroty)
        {
            _storeWebQueryReposiroty = storeWebQueryReposiroty;
        }
        // GET: Stores
        public ActionResult StoreDetail()
        {
            Load();
            int storeId = 0;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["storeId"]))
            {
                storeId = int.Parse(HttpContext.Request.QueryString["storeId"]);
            }

            var storeItem = _storeWebQueryReposiroty.GetStoreDetailsForWeb(storeId, LanguageId);

            return View("StoreDetail", storeItem);
        }
    }
}