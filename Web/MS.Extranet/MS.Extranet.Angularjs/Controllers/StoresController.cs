using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Core.Queries.Stores;
using MS.Extranet.Angularjs.Base;
using MS.ExtranetResources;

namespace MS.Extranet.Angularjs.Controllers
{
    public class StoresController : CustomController
    {
        ILocationQueryReposiroty _locationQueryReposiroty { get; set; }

        IStoreQueryReposiroty _storeQueryReposiroty { get; set; }

        public StoresController(ILocationQueryReposiroty locationQueryReposiroty, IStoreQueryReposiroty storeQueryReposiroty)
        {
            _locationQueryReposiroty = locationQueryReposiroty;
            _storeQueryReposiroty = storeQueryReposiroty;
        }

        [Authorize]
        public ActionResult SaveStore()
        {
            Load();
            var districtsCombo = new List<ListItem> { new ListItem(Resources.SelectArea, "") };
            districtsCombo.AddRange(_locationQueryReposiroty.GetDistrictsForCombo()
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlDistricts"] = districtsCombo;

            var countriesCombo = new List<ListItem> { new ListItem(Resources.SelectCity, "") };
            countriesCombo.AddRange(_locationQueryReposiroty.GetCitiesForComboByLanguage(CurrentUser.LanguageId, 3)
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlCityList"] = countriesCombo;

            ViewData["IdLanguageId"] = CurrentUser.LanguageId;
            ViewData["IdStore"] = CurrentUser.IdStore;
            return View();
        }

        [Authorize]
        public ActionResult ListStores()
        {
            Load();
            ViewData["HasStores"] = _storeQueryReposiroty.GetStoresByUserId(CurrentUser.UserId).Any();
            return View();
        }
    }
}