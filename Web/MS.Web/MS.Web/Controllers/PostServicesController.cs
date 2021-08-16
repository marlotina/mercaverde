using System.Linq;
using System.Web.Http;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Posts;
using MS.Utils;
using MS.Web.Models;

namespace MS.Web.Controllers
{
    public class PostServicesController : ApiController
    {
        private readonly IPostsWebQueryReposiroty _postsWebQueryReposiroty;

        public PostServicesController(IPostsWebQueryReposiroty postsWebQueryReposiroty)
        {
            _postsWebQueryReposiroty = postsWebQueryReposiroty;
        }

        [HttpPost]
        [Route("api/Posts/List/")]
        public NewsListItems List(Search.PaginationFilter filter)
        {
            var listPosts = _postsWebQueryReposiroty.GetPosts(filter.StartItem, filter.NumItems, filter.LanguageId);

            return listPosts;
        }
    }
}
