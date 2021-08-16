using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Posts;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Posts
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly IMsContext _context;

        public DeletePostCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (DeletePostCommand)commandObj;

                var post = new Post();

                if (command.IdPost != 0)
                {
                    post = _context.Post.FirstOrDefault(p => p.IdPost == command.IdPost);
                }
                if (post != null)
                {
                    if (!post.IsPublished)
                    {
                        post.Deleted = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new CommandException("PostIsPublished", "##PostIsPublished##");
                    }    
                }
            }
            catch (Exception ex)
            {
                throw new CommandException("DeletePostCommandHandler", ex.Message);
            }
        }
    }
}
