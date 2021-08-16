using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Posts;
using MS.CommandQuery.Core.Queries.Posts;
using MS.Extranet.Angularjs.Models;

namespace MS.Extranet.Angularjs.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostQueryReposiroty _postQueryReposiroty;
        private readonly ICommandExecutor _commandExecutor;

        public PostController(IPostQueryReposiroty postQueryReposiroty, ICommandExecutor commandExecutor)
        {
            _postQueryReposiroty = postQueryReposiroty;
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        [Authorize]
        [Route("api/Post/List/{userId:int}")]
        public IEnumerable<Posts.Post> List(int userId)
        {
            var listPosts = _postQueryReposiroty.GetPostsByUserId(userId);

            var result = listPosts.Select(listPost => new Posts.Post()
            {
                IdPost = listPost.IdPost,
                HasRevised = listPost.HasRevised,
                IsPublished = listPost.IsPublished,
                Title = listPost.Title,
                LastActivity = listPost.ModificationDate.ToShortDateString()
            }).ToList();

            return result;
        }

        [Authorize]
        public Posts.Post Get(int id)
        {
            var post = _postQueryReposiroty.GetPostById(id);
            if (post == null)
            {
                return new Posts.Post(){IdPost = 0, 
                    LanguageId = null, 
                    HasRevised = false, 
                    IsPublished = false};
            }

            return new Posts.Post()
            {
                IdPost = post.IdPost,
                Title = post.Title,
                Text = post.Text,
                UserId = post.UserId,
                LanguageId = post.LanguageId,
                IsPublished = post.IsPublished,
                HasRevised = post.HasRevised
            };
            
        }
        
        [Authorize]
        [Route("api/Post/")]
        public HttpResponseMessage Post(Posts.Post post)
        {
            try
            {
                var commands = new List<ICommand>
                {
                    new SavePostCommand()
                    {
                        Title = post.Title, 
                        IsPublished = post.IsPublished,
                        LanguageId = post.LanguageId,
                        IdPost = post.IdPost,
                        UserId = post.UserId,
                        Text = post.Text
                    },
                };

                _commandExecutor.Execute(commands);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ExtranetResources.Resources.InternalError));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/Post/Delete/{postId:int}")]
        public HttpResponseMessage DeleteStore(int postId)
        {
            if (postId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var commands = new List<ICommand>();

                commands.Add(
                    new DeletePostCommand()
                    {
                        IdPost = postId
                    });

                _commandExecutor.Execute(commands);
            }
            catch (CommandException ex)
            {
                if (ex.Code == "PostIsPublished")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ExtranetResources.Resources.DontDeletePublishPost);
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("api/Post/UploadImage")]
        public HttpResponseMessage UploadImagePost()
        {
            var url = string.Empty;
            var response = new HttpResponseMessage();

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["file"];

                if (httpPostedFile != null)
                {
                    var listFileName = httpPostedFile.FileName.Split('.');

                    var fileName = listFileName[0] + DateTime.Now.ToString("ddMMyymm") + "." + listFileName[1];
                    var fileSavePath = Path.Combine(ConfigurationManager.AppSettings["PostsImagesFolder"], fileName);

                    if (File.Exists(fileSavePath))
                    {
                        try
                        {
                            File.Delete(fileSavePath);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    httpPostedFile.SaveAs(fileSavePath);
                    url = ConfigurationManager.AppSettings["PostsImagesUrl"] + fileName; 
                }
            }

            response.Content = new StringContent(url);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return response;
        }
    }
}
