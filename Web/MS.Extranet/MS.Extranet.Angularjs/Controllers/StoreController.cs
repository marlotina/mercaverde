using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;
using MS.CommandQuery.Core.Commands.Stores;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Core.Queries.Stores;
using MS.Extranet.Angularjs.Models;
using MS.Utils;

namespace MS.Extranet.Angularjs.Controllers
{
    public class StoreController : ApiController
    {
        private readonly IStoreQueryReposiroty _storeQueryReposiroty;
        private readonly ICommandExecutor _commandExecutor;
        private readonly ICategoriesQueryReposiroty _categoriesQueryReposiroty;
        private readonly ILabelsQueryReposiroty _labelsQueryReposiroty;
        
        public StoreController(IStoreQueryReposiroty storeQueryReposiroty, 
            ICommandExecutor commandExecutor,
            ICategoriesQueryReposiroty categoriesQueryReposiroty,
            ILabelsQueryReposiroty labelsQueryReposiroty)
        {
            _storeQueryReposiroty = storeQueryReposiroty;
            _commandExecutor = commandExecutor;
            _labelsQueryReposiroty = labelsQueryReposiroty;
            _categoriesQueryReposiroty = categoriesQueryReposiroty;
        }

        
        [HttpGet]
        [Authorize]
        [Route("api/Store/List/{storeId:int}")]
        public IEnumerable<Stores.Store> List(int storeId)
        {
            var storeList = _storeQueryReposiroty.GetStoresByUserId(storeId);

            var result = storeList.Select(ls => new Stores.Store()
            {
                IdStore = ls.IdStore,
                Name = ls.Name,
                IsPublished = ls.IsPublished,
                Email = ls.Email,
                LastActivity = ls.LastActivity.ToShortDateString()
            }).ToList();

            return result;
        }

        [Authorize]
        public Stores.Store Get(int id)
        {
            var store = _storeQueryReposiroty.GetStoreById(id);
            if (store == null)
            {
                return new Stores.Store()
                {
                    IdStore= 0,
                    Longitude = "2.162104999999997",
                    Latitude = "41.3968913"
                };
            }

            return new Stores.Store()
            {
                IdStore = store.IdStore,
                UserId = store.UserId,
                Email = store.Email,
                Name = store.Name,
                Street = store.StreetComplete,
                Phone = store.Phone,
                TimeTable = store.TimeTable,
                CityId = store.CityId,
                IsPublished = store.IsPublished,
                DistrictId = store.DistrictId,
                Longitude = !string.IsNullOrEmpty(store.Longitude) ? store.Longitude : "2.162104999999997",
                Latitude = !string.IsNullOrEmpty(store.Longitude) ? store.Latitude : "41.3968913",
                PrefixPhone = store.PrefixPhone,
                MobilePhone = store.MobilePhone,
                PostalCode = store.PostalCode
            };
        }

        [HttpPost]
        [Authorize]
        [Route("api/Store/Save")]
        public HttpResponseMessage SaveStore(Stores.Store store)
        {
            int newStoreId;

            try
            {
                var commands = new List<ICommand>
                {
                    new SaveStoreCommand()
                    {
                        IdStore = store.IdStore,
                        Email = store.Email,
                        Name = store.Name,
                        StreetComplete = store.Street,
                        Phone = store.Phone,
                        TimeTable = store.TimeTable,
                        IsPublished = store.IsPublished,
                        Longitude = store.Longitude,
                        DistrictId = store.DistrictId,
                        Latitude = store.Latitude,
                        UserId = store.UserId,
                        CityId =  store.CityId,
                        MobilePhone = store.MobilePhone,
                        PrefixPhone = store.PrefixPhone,
                        PostalCode = store.PostalCode
                    },
                };

                _commandExecutor.Execute(commands);

                newStoreId = _storeQueryReposiroty.GetStoreByName(store.Name).IdStore;
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK, newStoreId);
        }

        [HttpPost]
        [Route("api/Store/UploadImages")]
        public KeyValuePair<bool, string> UploadImages()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files["Filedata"];
                    var storeId = int.Parse(HttpContext.Current.Request.QueryString["storeId"]);

                    if (httpPostedFile != null)
                    {
                        var savePath = ConfigurationManager.AppSettings["StoresImagesFolder"] + storeId + "\\";
                        
                        var fileName = httpPostedFile.FileName;

                        var fileSavePath = Path.Combine(savePath, fileName);
                        if (!Directory.Exists(savePath))
                        {
                            Directory.CreateDirectory(savePath);
                        }
                        var listFileName = fileName.Split('.');

                        var count = 1;
                        while (File.Exists(fileSavePath))
                        {
                            fileName = listFileName[0] + count + "." + listFileName[1];
                            fileSavePath = Path.Combine(savePath, fileName);
                            count++;
                        }

                        httpPostedFile.SaveAs(fileSavePath);

                        var commands = new List<ICommand>
                        {
                            new SaveStoreImagesCommand()
                            {
                                StoreId = storeId,
                                ImageUrlList = ConfigurationManager.AppSettings["StoresImagesUrl"] + storeId + "/" + fileName,
                                Action = 4
                            },
                        };

                        _commandExecutor.Execute(commands);

                        return new KeyValuePair<bool, string>(true, ConfigurationManager.AppSettings["StoresImagesUrl"] + storeId + "/" + fileName);
                    }

                    return new KeyValuePair<bool, string>(false, ExtranetResources.Resources.CouldNotGetUploadedFile);
                }

                return new KeyValuePair<bool, string>(false, ExtranetResources.Resources.NotFileToUpload);
            }
            catch (Exception)
            {
                return new KeyValuePair<bool, string>(false, ExtranetResources.Resources.DontDoAction);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/SaveImagesOrder")]
        public HttpResponseMessage SveImageOrder(int storeId, string storeImagesOrderList)
        {
            try
            {
                var storeImagesOrderArray = storeImagesOrderList.Split(',');
                var commands = new List<ICommand>
                {
                    new SaveStoreImagesOrderCommand()
                    {
                        IdStore = storeId,
                        Order = storeImagesOrderArray
                    },
                };

                _commandExecutor.Execute(commands);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/DeleteImage/{storeImageId}")]
        public HttpResponseMessage DeleteImageStore(int storeImageId)
        {
            try
            {
                var commands = new List<ICommand>
                {
                    new DeleteStoreImagesCommand()
                    {
                        IdStoreImage = storeImageId
                    },
                };

                _commandExecutor.Execute(commands);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/Image/{storeId:int}")]
        public IList<Stores.StoreImage> ListImages(int storeId)
        {
            var storeImageList = _storeQueryReposiroty.GetStoreImagesByStoreId(storeId);

            return storeImageList.Select(storeImage => new Stores.StoreImage()
            {
                IdStoreImage = storeImage.IdStoreImage,
                ImageUrl = storeImage.Url,
                IsMain =
                    storeImage.IsMain,
                Order = storeImage.Order,
                StoreId = storeImage.StoreId
            }).ToList();
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/Description/{storeId:int}")]
        public Stores.StoreDescription ListDescriptions(int storeId)
        {
            var storeDescriptionList = _storeQueryReposiroty.GetStoreDescriptionsByStoreId(storeId);
            var languageDictionary = new LanguageDictionary();
            var storeDescriptions = new Stores.StoreDescription();

            StoreDescription storeDescription;
            storeDescriptions.IdStore = storeId;
            storeDescriptions.DescriptionList = new List<Stores.DescriptionItem>();
            foreach (var languageInfo in languageDictionary.LanguageInfoDictionary)
            {
                storeDescription = storeDescriptionList.FirstOrDefault(d => d.LanguageId == languageInfo.Key);
                if (storeDescription != null)
                {
                    storeDescriptions.DescriptionList.Add(new Stores.DescriptionItem()
                    {
                        IdLanguage = storeDescription.LanguageId,
                        LanguageName = languageDictionary.LanguageInfoDictionary[storeDescription.LanguageId],
                        Description = storeDescription.Description,
                        ShortDescription = storeDescription.ShortDescription,
                        Title = storeDescription.Title
                    });
                }
                else
                {
                    storeDescriptions.DescriptionList.Add(new Stores.DescriptionItem()
                    {
                        IdLanguage = languageInfo.Key,
                        LanguageName = languageInfo.Value,
                    });
                }
            }

            return storeDescriptions;
        }

        [HttpPost]
        [Authorize]
        [Route("api/Store/Description/Save")]
        public HttpResponseMessage SaveDescription(Stores.StoreDescription storeDescriptions)
        {
            if (storeDescriptions == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var commands = new List<ICommand>();

                foreach (var storeDescription in storeDescriptions.DescriptionList)
                {
                    commands.Add(
                        new SaveStoreDescriptionCommand()
                        {
                            StoreId = storeDescriptions.IdStore,
                            Title = storeDescription.Title,
                            Description = storeDescription.Description,
                            ShortDescription = storeDescription.ShortDescription,
                            LanguageId = storeDescription.IdLanguage
                        });
                }

                _commandExecutor.Execute(commands);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/CLassification/{storeId:int}/{languageId:int}")]
        public Stores.StoreClassification ListCLassification(int storeId, int languageId)
        {
            var classification = new Stores.StoreClassification();
            classification.StoreId = storeId;

            var categoryActiveList = _storeQueryReposiroty.GetStoreCategoriesByStoreId(storeId);
            Stores.ItemCheckBox item;

            var categoryList = new List<Stores.ItemCheckBox>();
            foreach (var category in _categoriesQueryReposiroty.GetCategoriesListByLanguage(languageId))
            {
                item = new Stores.ItemCheckBox();
                item.Text = category.Text;
                item.Value  = int.Parse(category.Value);
                item.Checked = categoryActiveList.Any(c => c.IdCategory == item.Value);
                categoryList.Add(item);
            }

            classification.CategoryList = categoryList;

            var labelActiveList = _storeQueryReposiroty.GetStoreLabelsByStoreId(storeId);
            var labelList = new List<Stores.ItemCheckBox>();
            foreach (var label in _labelsQueryReposiroty.GetLabelsListByLanguage(languageId))
            {
                item = new Stores.ItemCheckBox();
                item.Text = label.Text;
                item.Value = int.Parse(label.Value);
                item.Checked = labelActiveList.Any(c => c.IdLabel == item.Value);
                labelList.Add(item);
            }

            classification.LabelList = labelList;

            return classification;
        }


        [HttpPost]
        [Authorize]
        [Route("api/Store/CLassification/Save")]
        public HttpResponseMessage SaveCLassification(Stores.StoreClassification storeClassification)
        {
            try
            {
                var categoriesActive = new List<int>();
                foreach (var category in storeClassification.CategoryList)
                {
                    if (category.Checked)
                    {
                        categoriesActive.Add(category.Value);
                    }
                }

                var lablesActive = new List<int>();
                foreach (var label in storeClassification.LabelList)
                {
                    if (label.Checked)
                    {
                        lablesActive.Add(label.Value);
                    }
                    
                }

                var commands = new List<ICommand>();

                commands.Add(new SaveStoreCategoriesCommand()
                {
                    IdStore = storeClassification.StoreId,
                    CategoryList = categoriesActive
                });

                commands.Add(new SaveStoreLabelsCommand()
                {
                    IdStore = storeClassification.StoreId,
                    LabeList = lablesActive
                });
                
                _commandExecutor.Execute(commands);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/Delete/{storeId:int}")]
        public HttpResponseMessage DeleteStore(int storeId)
        {
            if (storeId == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var commands = new List<ICommand>();

                commands.Add(
                    new DeleteStoreCommand()
                    {
                        IdStore = storeId
                    });

                _commandExecutor.Execute(commands);
            }
            catch (CommandException ex)
            {
                if (ex.Code == "PropertyIsPublished")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ExtranetResources.Resources.DontDeletePublishStore);
                }

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Store/Publish/{storeId:int}/{languageId:int}")]
        public Stores.StorePublish GetPublishInfo(int storeId, int languageId)
        {
            var store = _storeQueryReposiroty.GetStoreById(storeId);
            if (store == null)
            {
                return new Stores.StorePublish();
            }

            return new Stores.StorePublish()
            {
                IdStore = store.IdStore,
                IsPublished = store.IsPublished,
                IsRevised = store.IsRevised,
                UrlStore = UrlHelper.GetStoreFullUrl(store.IdStore, languageId)
            };
        }

        [HttpPost]
        [Authorize]
        [Route("api/Store/Publish/Save")]
        public HttpResponseMessage SaveStore(Stores.StorePublish store)
        {
            try
            {
                var commands = new List<ICommand>
                {
                    new PublishStoreCommand()
                    {
                        IdStore = store.IdStore,
                        IsPublished = store.IsPublished
                        
                    },
                };

                _commandExecutor.Execute(commands);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExtranetResources.Resources.DontDoAction);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
