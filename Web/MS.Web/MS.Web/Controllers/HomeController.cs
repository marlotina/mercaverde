using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Core.Queries.Stores;
using MS.Web.Base;
using MS.Web.Models;

namespace MS.Web.Controllers
{
    public class HomeController : CustomController
    {
        private ILocationWebQueryReposiroty _locationWebQueryReposiroty { get; set; }

        private ICategoriesWebQueryReposiroty _categoriesWebQueryReposiroty { get; set; }

        private IStoreWebQueryReposiroty _storeWebQueryReposiroty { get; set; }

        public HomeController(ILocationWebQueryReposiroty locationWebQueryReposiroty, ICategoriesWebQueryReposiroty categoriesWebQueryReposiroty, IStoreWebQueryReposiroty storeWebQueryReposiroty)
        {
            _locationWebQueryReposiroty = locationWebQueryReposiroty;
            _categoriesWebQueryReposiroty = categoriesWebQueryReposiroty;
            _storeWebQueryReposiroty = storeWebQueryReposiroty;
        }

        public ActionResult Index()
        {
            Load();

            var citiesCombo = new List<ListItem> { new ListItem("Buscar...", "") };
            citiesCombo.AddRange(_locationWebQueryReposiroty.GetCitiesForComboByLanguage(1, 3)
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlCityList"] = citiesCombo;

            var itemList = new List<ListCustomItem>();
            var categories = _categoriesWebQueryReposiroty.GetCategoriesListByLanguage(1);
            foreach (var category in categories)
            {
                if(category.ParentCategoryId == null)
                itemList.Add(new ListCustomItem()
                {
                    Text = category.Name,
                    Value = category.IdCategory,
                    Active = category.IdCategory == 3
                });
            }

            ViewData["CategoryList"] = itemList;

            var lastStores = _storeWebQueryReposiroty.GetLastStoresWebSearch(1);

            ViewData["LastStores"] = lastStores;

            return View();
        }

        public ActionResult About()
        {
            Load();
            return View();
        }

        public ActionResult Contact()
        {
            Load();
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            Load();
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            Load();
            return View();
        }

        public ActionResult Faq()
        {
            Load();
            return View();
        }
    }
}