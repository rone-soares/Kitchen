using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiKitchen.Controllers.Registrations
{
    [GroupSwagger("Kitchen-Areas")]
    public class KitchenAreaController : ApiController
    {
        private readonly IKitchenAreaAppService kitchenAreaAppService;

        public KitchenAreaController(IKitchenAreaAppService kitchenAreaAppService)
        {
            this.kitchenAreaAppService = kitchenAreaAppService;
        }

        /// <summary>
        /// List the kitchen area by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("kitchen-areas/{id:int}")]
        [ResponseType(typeof(IEnumerable<KitchenAreaResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = kitchenAreaAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the kitchens
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("kitchen-areas")]
        [ResponseType(typeof(IEnumerable<KitchenAreaResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = kitchenAreaAppService.Select();

            return Ok(response);
        }

        /// <summary>
        /// Insert a new kitchen
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("kitchen-area")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] KitchenAreaRequest request)
        {
            var response = kitchenAreaAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// Kitchen update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("kitchen-area")]
        public IHttpActionResult Update([FromBody] KitchenAreaRequest request)
        {
            kitchenAreaAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the kitchen
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("kitchen-areas/{id:int}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            kitchenAreaAppService.Delete(id);

            return Ok();
        }
    }
}
