using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Languages;
using MS.CommandQuery.Core.Queries.Locations;
using MS.CommandQuery.Core.Queries.Users;
using MS.Extranet.Angularjs.Base;
using MS.ExtranetResources;

namespace MS.Extranet.Angularjs.Controllers
{
    public class AccountController : CustomController
    {
        ILocationQueryReposiroty _locationQueryReposiroty { get; set; }

        ILanguageQueryReposiroty _languageQueryRepository { get; set; }

        IUserQueryReposiroty _userQueryReposiroty { get; set; }

        public AccountController(ILocationQueryReposiroty locationQueryReposiroty, ILanguageQueryReposiroty languageQueryRepository, IUserQueryReposiroty userQueryReposiroty)
        {
            _locationQueryReposiroty = locationQueryReposiroty;
            _languageQueryRepository = languageQueryRepository;
            _userQueryReposiroty = userQueryReposiroty;
        }

        [Authorize]
        public ActionResult ModifyUser()
        {
            Load();
            var countriesCombo = new List<ListItem> { new ListItem(Resources.SelectedCountry, "") };
            countriesCombo.AddRange(_locationQueryReposiroty.GetCountriesForComboByLanguage(CurrentUser.LanguageId)
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlCountryList"] = countriesCombo;

            var languageCombo = new List<ListItem> { new ListItem(Resources.SelectedLanguage, "") };
            languageCombo.AddRange(_languageQueryRepository.GetLanguagesComboByLanguageId()
                .Select(item => new ListItem(item.Text, item.Value)));
            ViewData["DdlLanguageList"] = languageCombo;
            
            LoadCalendar();

            return View();
        }

        private void LoadCalendar()
        {
            var dayList = new List<ListItem> { new ListItem(Resources.Day, "0") };
            for (int i = 0; i <= 31; i++)
            {
                dayList.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ViewData["DdlDayList"] = new SelectList(dayList, "value", "text");

            var yearList = new List<ListItem> { new ListItem(Resources.Year, "0") };
            for (int i = 2005; i >= 1900; i--)
            {
                yearList.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ViewData["DdlyYearList"] = new SelectList(yearList, "value", "text");

            var monthList = new List<ListItem>
            {
                new ListItem(Resources.Mes, "0"),
                new ListItem(Resources.January, "1"),
                new ListItem(Resources.February, "2"),
                new ListItem(Resources.March, "3"),
                new ListItem(Resources.April, "4"),
                new ListItem(Resources.May, "5"),
                new ListItem(Resources.June, "6"),
                new ListItem(Resources.July, "7"),
                new ListItem(Resources.August, "8"),
                new ListItem(Resources.September, "9"),
                new ListItem(Resources.October, "10"),
                new ListItem(Resources.November, "11"),
                new ListItem(Resources.December, "12")
            };

            ViewData["DdlMonthList"] = new SelectList(monthList, "value", "text");
        }

    }
}