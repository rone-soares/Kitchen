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
    public class OrderItemController : ApiController
    {
        private readonly IOrderItemAppService orderItemAppService;

        public OrderItemController(IOrderItemAppService orderItemAppService)
        {
            this.orderItemAppService = orderItemAppService;
        }        

        /// <summary>
        /// List the order items by order
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("orders/{id:int}/items")]
        [ResponseType(typeof(IEnumerable<OrderItemResponse>))]
        public IHttpActionResult SelectByOrder([FromUri] int id)
        {
            var response = orderItemAppService.SelectByOrder(id);

            return Ok(response);
        }

        /// <summary>
        /// Insert a new order item
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("orders/{id:int}/item")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Insert([FromBody] OrderItemRequest request)
        {
            var response = orderItemAppService.Insert(request);

            return Ok(response);
        }

        /// <summary>
        /// order item update
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("orders/{id:int}/item")]
        public IHttpActionResult Update([FromBody] OrderItemRequest request)
        {
            orderItemAppService.Update(request);

            return Ok();
        }

        /// <summary>
        /// Delete the order item
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("orders/{idOrder:int}/item/{idItem:int}")]
        public IHttpActionResult Delete([FromUri] int idItem)
        {
            orderItemAppService.Delete(idItem);

            return Ok();
        }
    }
}
