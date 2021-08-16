using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MS.CommandQuery.Core.Queries.Languages;
using MS.CommandQuery.Core.Queries.Posts;
using MS.Extranet.Angularjs.Base;
using MS.ExtranetResources;

namespace MS.Extranet.Angularjs.Controllers
{
    public class PostsController : CustomController
    {
        ILanguageQueryReposiroty _languageQueryRepository { get; set; }

        IPostQueryReposiroty _postQueryReposiroty { get; set; }

        public PostsController(ILanguageQueryReposiroty languageQueryRepository, IPostQueryReposiroty postQueryReposiroty)
        {
            _languageQueryRepository = languageQueryRepository;

            _postQueryReposiroty = postQueryReposiroty;
        }

       [Authorize]
        public ActionResult SavePost()
        {
            Load();
            var languageCombo = new List<ListItem> { new ListItem(Resources.SelectedLanguage, "") };
            languageCombo.AddRange(_languageQueryRepository.GetLanguagesComboByLanguageId()
                .Select(item => new ListItem(item.Text, item.Value)));
             
            ViewData["DdlLanguageList"] = languageCombo;
            ViewData["IdPost"] = CurrentUser.IdPost;

            return View();
        }

        [Authorize]
        public ActionResult ListPosts()
        {
            Load();
            ViewData["HasPosts"] = _postQueryReposiroty.GetPostsByUserId(CurrentUser.UserId).Any();
            return View();
        }
    }
}