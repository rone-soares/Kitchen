using DataTransfer.Responses.Registrations;
using Domain.Entities.Orders.Enums;
using System;

namespace DataTransfer.Responses.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public WaiterResponse Waiter { get; set; }
        public PointOfSaleResponse PointOfSale { get; set; }
        public TableResponse Table { get; set; }
        public DateTime CreationDate { get; set; }
        public StatusOrderEnum StatusOrder { get; set; }
    }
}
