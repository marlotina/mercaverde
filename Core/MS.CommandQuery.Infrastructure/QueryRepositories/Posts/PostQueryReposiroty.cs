using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Queries.Posts;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Posts
{
    public class PostQueryReposiroty : QueryBase, IPostQueryReposiroty
    {
        public PostQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public Post GetPostById(int postId)
        {
            var post = Context.Post.FirstOrDefault(p => p.IdPost == postId);

            return post;
        }

        public IList<Post> GetPostsByUserId(int userId)
        {
            return Context.Post.Where(p => p.UserId == userId && p.Deleted == false).ToList();
        }
    }
}
