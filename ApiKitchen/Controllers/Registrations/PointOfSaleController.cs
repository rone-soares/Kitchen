using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Registrations;
using DataTransfer.Requests;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Library.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apipointofsale.Controllers.Registrations
{
    [GroupSwagger("Points-of-Sales")]
    public class PointOfSaleController : ApiController
    {
        private readonly IPointOfSaleAppService pointOfSaleAppService;

        public PointOfSaleController(IPointOfSaleAppService pointOfSaleAppService)
        {
            this.pointOfSaleAppService = pointOfSaleAppService;
        }

        /// <summary>
        /// List the point of sale by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("points-of-sales/{id:int}")]
        [ResponseType(typeof(IEnumerable<PointOfSaleResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = pointOfSaleAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the points of sales 
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("points-of-sales")]
        [ResponseType(typeof(IEnumerable<PointOfSaleResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = pointOfSaleAppService.Select();

            return Ok(response);
        }

        /// <summary>
        /// Insert a new point of sale
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("point-of-sale")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] PointOfSaleRequest request)
        {
            var response = pointOfSaleAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// Point of sale update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("point-of-sale")]
        public IHttpActionResult Update([FromBody] PointOfSaleRequest request)
        {
            pointOfSaleAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the point of sale
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("points-of-sales/{id:int}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            pointOfSaleAppService.Delete(id);

            return Ok();
        }
    }
}
