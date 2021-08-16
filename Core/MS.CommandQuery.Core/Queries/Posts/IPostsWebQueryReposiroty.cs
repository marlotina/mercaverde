using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Posts
{
    public interface IPostsWebQueryReposiroty
    {
        NewsListItems GetPosts(int startItem, int numItems, int languageId);

        Post GetPostsBytId(int postId);
    }
}
