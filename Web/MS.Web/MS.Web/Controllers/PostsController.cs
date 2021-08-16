using System.Web.Mvc;
using MS.CommandQuery.Core.Queries.Posts;
using MS.Web.Base;

namespace MS.Web.Controllers
{
    public class PostsController : CustomController
    {
        public IPostsWebQueryReposiroty _postsWebQueryReposiroty { get; set; }

        public PostsController(IPostsWebQueryReposiroty postsWebQueryReposiroty)
        {
            _postsWebQueryReposiroty = postsWebQueryReposiroty;
        }

        public ActionResult PostList()
        {
            Load();
            ViewData["IdLanguage"] = LanguageId;
            return View();
        }

        public ActionResult PostDetail()
        {
            Load();
            int postId = 0;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["postId"]))
            {
                postId = int.Parse(HttpContext.Request.QueryString["postId"]);
            }

            var postitem = _postsWebQueryReposiroty.GetPostsBytId(postId);

            return View("PostDetail", postitem);
        }
    }
}