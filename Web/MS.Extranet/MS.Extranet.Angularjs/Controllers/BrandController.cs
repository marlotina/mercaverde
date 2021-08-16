using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;
using MS.CommandQuery.Core.Queries.Brands;
using MS.Extranet.Angularjs.Models;

namespace MS.Extranet.Angularjs.Controllers
{
    public class BrandController : ApiController
    {
        private readonly IBrandQueryReposiroty _brandQueryReposiroty;
        private readonly ICommandExecutor _commandExecutor;

        public BrandController(IBrandQueryReposiroty brandQueryReposiroty, ICommandExecutor commandExecutor)
        {
            _brandQueryReposiroty = brandQueryReposiroty;
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        [Route("api/Brand/List/{brandId:int}")]
        public IEnumerable<Brands.Brand> List(int brandId)
        {
            var brandList = _brandQueryReposiroty.ListBrandsByUserId(brandId);

            var result = brandList.Select(ls => new Brands.Brand()
            {
                IdBrand = ls.IdBrand,
                Name = ls.Name
            }).ToList();


            return result;
        }

        public Brands.Brand Get(int id)
        {
            var brand = _brandQueryReposiroty.GetBrandById(id);
            if (brand == null)
            {
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                return new Brands.Brand() { IdBrand= 0 };
            }
            return new Brands.Brand()
            {
                IdBrand = brand.IdBrand,
                Name = brand.Name
            };

        }

        // POST api/<controller>
        public HttpResponseMessage Post(Brands.Brand brand)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

                var commands = new List<ICommand>
                {
                    new SaveBrandCommand()
                    {
                        IdBrand = brand.IdBrand, 
                        Name= brand.Name,
                    },
                };

                _commandExecutor.Execute(commands);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, brand);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = brand.IdBrand}));
                return response;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.ExpectationFailed));
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Brands.Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (brand.IdBrand == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var commands = new List<ICommand>
                {
                    new SaveBrandCommand()
                    {
                        IdBrand = brand.IdBrand, 
                        Name = brand.Name
                    },
                };

                _commandExecutor.Execute(commands);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
