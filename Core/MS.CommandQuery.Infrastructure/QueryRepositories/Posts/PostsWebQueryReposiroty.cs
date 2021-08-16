using System.Linq;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Posts;
using MS.CommandQuery.Infrastructure.DbContexts;
using MS.Utils;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Posts
{
    public class PostsWebQueryReposiroty : QueryBase, IPostsWebQueryReposiroty
    {
        public PostsWebQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public Post GetPostById(int postId)
        {
            var post = Context.Post.FirstOrDefault(p => p.IdPost == postId);

            return post;
        }

        public Post GetPostsBytId(int postid)
        {
            var post = Context.Post.FirstOrDefault(n => n.IdPost == postid);

            return post;
        }

        public NewsListItems GetPosts(int startItem, int numItems, int languageId)
        {
            var postList = new NewsListItems();
            const string query = "EXEC spPostsWebSearchList @startItem = {0},  @numItems = {1}";

            var qlQuery = string.Format(query, startItem, numItems);
            postList.ListNews = Context.Database.SqlQuery<NewsWebItem>(qlQuery).ToList();
            postList.NumItems = numItems;
            postList.StartItem = startItem;

            foreach (var posts in postList.ListNews.ToList())
            {
                posts.Url = UrlHelper.GetPosturl(posts.IdItem, languageId);
            }


            if (postList.ListNews.Any())
                postList.TotalItems = postList.ListNews.FirstOrDefault().TotalItems;

            return postList;
        }
    }
}
