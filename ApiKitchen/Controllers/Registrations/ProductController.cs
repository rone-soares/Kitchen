using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apiproduct.Controllers.Registrations
{
    [GroupSwagger("Products")]
    public class ProductController : ApiController
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        /// <summary>
        /// List the product by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("products/{id:int}")]
        [ResponseType(typeof(IEnumerable<ProductResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = productAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List the products by kitchen
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("kitchen-areas/{id:int}/products")]
        [ResponseType(typeof(IEnumerable<ProductResponse>))]
        public IHttpActionResult SelectByKitchen([FromUri] int id)
        {
            var response = productAppService.SelectByKitchenArea(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the products
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("products")]
        [ResponseType(typeof(IEnumerable<ProductResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = productAppService.Select();

            return Ok(response);
        }

        /// <summary>
        /// Insert a new product
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("product")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] ProductRequest request)
        {
            var response = productAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// Product update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("product")]
        public IHttpActionResult Update([FromBody] ProductRequest request)
        {
            productAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("products/{id:int}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            productAppService.Delete(id);

            return Ok();
        }
    }
}
