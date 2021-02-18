using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiKitchen.Controllers.Registrations
{
    [GroupSwagger("Waiters")]
    public class WaiterController : ApiController
    {
        private readonly IWaiterAppService waiterAppService;

        public WaiterController(IWaiterAppService waiterAppService)
        {
            this.waiterAppService = waiterAppService;
        }

        /// <summary>
        /// List the waiter by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("waiters/{id:int}")]
        [ResponseType(typeof(IEnumerable<WaiterResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = waiterAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the waiters
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("waiters")]
        [ResponseType(typeof(IEnumerable<WaiterResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = waiterAppService.Select();

            return Ok(response);
        }

        /// <summary>
        /// Insert a new waiter
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("waiter")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] WaiterRequest request)
        {
            var response = waiterAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// Waiter update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("waiter")]
        public IHttpActionResult Update([FromBody] WaiterRequest request)
        {
            waiterAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the waiter
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("waiters/{id:int}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            waiterAppService.Delete(id);

            return Ok();
        }
    }
}
