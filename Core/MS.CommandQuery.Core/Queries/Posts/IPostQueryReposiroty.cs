using System.Collections.Generic;
using MS.CommandQuery.Core.Entities.CMS;

namespace MS.CommandQuery.Core.Queries.Posts
{
    public interface IPostQueryReposiroty
    {
        Post GetPostById(int postId);

        IList<Post> GetPostsByUserId(int userId);
    }
}
