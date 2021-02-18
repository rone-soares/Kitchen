using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apitable.Controllers.Registrations
{
    [GroupSwagger("Tables")]
    public class TableController : ApiController
    {
        private readonly ITableAppService tableAppService;

        public TableController(ITableAppService tableAppService)
        {
            this.tableAppService = tableAppService;
        }

        /// <summary>
        /// List the table by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("tables/{id:int}")]
        [ResponseType(typeof(IEnumerable<TableResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = tableAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the tables
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("tables")]
        [ResponseType(typeof(IEnumerable<TableResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = tableAppService.Select();

            return Ok(response);
        }

        /// <summary>
        /// Insert a new table
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("table")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] TableRequest request)
        {
            var response = tableAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// Table update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("table")]
        public IHttpActionResult Update([FromBody] TableRequest request)
        {
            tableAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the table
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("tables/{id:int}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            tableAppService.Delete(id);

            return Ok();
        }
    }
}
