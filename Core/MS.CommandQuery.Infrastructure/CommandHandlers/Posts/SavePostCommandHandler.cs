using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Posts;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Posts
{
    public class SavePostCommandHandler : ICommandHandler<SavePostCommand>
    {
        private readonly IMsContext _context;

        public SavePostCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (SavePostCommand)commandObj;

                var post = new Post();

                if (command.IdPost != 0)
                {
                    post = _context.Post.FirstOrDefault(p => p.IdPost == command.IdPost);
                }

                if (post == null || post.IdPost == 0)
                {
                    post = new Post { CreationDate = DateTime.Now };
                    post.HasRevised = false;
                    post.IsPublished = false;
                    post.Deleted = false;
                }

                post.ModificationDate = DateTime.Now;
                post.Text = command.Text;
                post.Title = command.Title;
                post.Language = _context.Language.FirstOrDefault(l => l.IdLanguage == command.LanguageId);
                post.User = _context.User.FirstOrDefault(u => u.IdUser == command.UserId);

                if (post.IsPublished && !command.IsPublished)
                {
                    post.HasRevised = false;
                }

                post.IsPublished = command.IsPublished;

                if (command.IdPost == 0)
                {
                    _context.Post.Add(post);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CommandException("SavePostCommandHandler", ex.Message);
            }
            
        }
    }
}
