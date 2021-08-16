using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Locations;
using MS.Web.Base;
using MS.Web.Models;

namespace MS.Web.Controllers
{
    public class SearchController : CustomController
    {
        ILocationWebQueryReposiroty _locationWebQueryReposiroty { get; set; }

        ICategoriesWebQueryReposiroty _categoriesWebQueryReposiroty { get; set; }

        ILabelsWebQueryReposiroty _labelsWebQueryReposiroty { get; set; }

        protected string Idlocation { get; set; }
        protected string LocationName { get; set; }
        protected string IdLanguage { get; set; }
        protected IList<string> SelectedDistricts { get; set; }
        protected IList<string> SelectedCategories { get; set; }

        protected IList<string> SelectedLabels { get; set; }


        public SearchController(ILocationWebQueryReposiroty locationWebQueryReposiroty,
            ICategoriesWebQueryReposiroty categoriesWebQueryReposiroty,
            ILabelsWebQueryReposiroty labelsWebQueryReposiroty)
        {
            _locationWebQueryReposiroty = locationWebQueryReposiroty;
            _categoriesWebQueryReposiroty = categoriesWebQueryReposiroty;
            _labelsWebQueryReposiroty = labelsWebQueryReposiroty;
            SelectedCategories = new List<string>();
            SelectedDistricts = new List<string>();
            SelectedLabels = new List<string>();
        }
        
        public ActionResult List()
        {
            LoadCommon();

            return View();
        }

        public ActionResult Map()
        {
            LoadCommon();
            return View();
        }

        private void LoadCommon()
        {
            Load();

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pLocationId"]))
            {
                ViewData["IdLocation"] = Idlocation = HttpContext.Request.QueryString["pLocationId"];
            }
            else
            {
                ViewData["IdLocation"] = 1;
            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pLocationName"]))
            {
                ViewData["LocationName"] = LocationName = HttpContext.Request.QueryString["pLocationName"];
            }
            else
            {
                ViewData["LocationName"] = string.Empty;
            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pIdLanguage"]))
            {
                ViewData["IdLanguage"] = IdLanguage = HttpContext.Request.QueryString["pIdLanguage"];
            }
            else
            {
                ViewData["IdLanguage"] = LanguageId;
            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pDistrictsList"]))
            {
                SelectedDistricts = HttpContext.Request.QueryString["pDistrictsList"].Split(',');
                

            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pCategoryList"]))
            {
                SelectedCategories = HttpContext.Request.QueryString["pCategoryList"].Split(',');
            }

            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["pLabelList"]))
            {
                SelectedLabels = HttpContext.Request.QueryString["pLabelList"].Split(',');
            }


            var cityList = new List<ListItem> {new ListItem("Buscar...", "")};
            cityList.AddRange(_locationWebQueryReposiroty.GetCitiesForComboByLanguage(1, 3)
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlCityList"] = cityList;

            var itemList = new List<ListCustomItem>();
            var districts = _locationWebQueryReposiroty.GetDistrictsForFilter();
            foreach (var district in districts)
            {
                district.Selected = SelectedDistricts.Contains(district.Value);
                itemList.Add(new ListCustomItem()
                {
                    Value = int.Parse(district.Value),
                    Text = district.Text
                });
            }

            ViewData["DistrictList"] = itemList;

            itemList = new List<ListCustomItem>();
            var categories = _categoriesWebQueryReposiroty.GetCategoriesListByLanguage(1);
            foreach (var category in categories)
            {
                itemList.Add(new ListCustomItem()
                {
                    Active = SelectedCategories.Contains(category.IdCategory.ToString()),
                    Value = category.IdCategory,
                    Text = category.Name
                });
            }

            ViewData["CategoryList"] = itemList;

            itemList = new List<ListCustomItem>();
            var labels = _labelsWebQueryReposiroty.GetLabelsListByLanguage(1);
            foreach (var label in labels)
            {
                itemList.Add(new ListCustomItem()
                {
                    Active = SelectedLabels.Contains(label.IdCategory.ToString()),
                    Value = label.IdCategory,
                    Text = label.Name
                });
            }

            ViewData["LabelList"] = itemList;
            ViewData["ParamsQueryString"] = GetParamsForUrl();
        }

        private string GetParamsForUrl()
        {
            var queryParam = new StringBuilder();
            queryParam.Append("?pLocationId=" + Idlocation);
            queryParam.Append("&pLocationName=" + LocationName);
            if (SelectedDistricts.Any())
            {
                queryParam.Append("&pDistrictsList=" + String.Join(",", SelectedDistricts));
            }

            if (SelectedCategories.Any())
            {
                queryParam.Append("&pCategoryList=" + String.Join(",", SelectedCategories));
            }

            return queryParam.ToString();
        }
    }
}