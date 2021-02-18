using ApiKitchen.SwaggerExtensions;
using Business.Interfaces.Orders;
using DataTransfer.Requests.Orders;
using DataTransfer.Responses.Orders;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiKitchen.Controllers.Orders
{
    [GroupSwagger("Orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            this.orderAppService = orderAppService;
        }

        /// <summary>
        /// List the order by Id
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("orders/{id:int}")]
        [ResponseType(typeof(IEnumerable<OrderResponse>))]
        public IHttpActionResult SelectById([FromUri] int id)
        {
            var response = orderAppService.Select(id);

            return Ok(response);
        }

        /// <summary>
        /// List all the orders 
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("orders")]
        [ResponseType(typeof(IEnumerable<OrderResponse>))]
        public IHttpActionResult SelectAll()
        {
            var response = orderAppService.Select();

            return Ok(response);
        }        

        /// <summary>
        /// Insert a new order with items
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("order")]
        [ResponseType(typeof(int))]
        public IHttpActionResult CreateOrderWithItems([FromBody] OrderWithItemsRequest request)
        {
            var response = orderAppService.CreateAnOrderWithItems(request);

            return Ok(response);
        }

        /// <summary>
        /// Turn order to in progress
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("orders/{id:int}/in-progress")]
        public IHttpActionResult InProgressOrder([FromUri] int id)
        {
            orderAppService.InProgressOrder(id);

            return Ok();
        }

        /// <summary>
        /// Turn order to finished
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("orders/{id:int}/finished")]
        public IHttpActionResult FinishedOrder([FromUri] int id)
        {
            orderAppService.FinishedOrder(id);

            return Ok();
        }

        /// <summary>
        /// Cancel the order
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("orders/{id:int}/cancel")]
        public IHttpActionResult CancelOrder([FromUri] int id)
        {
            orderAppService.CancelOrder(id);

            return Ok();
        }
    }
}
