using Domain.Entities.Orders.Enums;
using System;

namespace DataTransfer.Requests.Orders
{
    public class OrderRequest : RequestBase
    {
        public int IdWaiter { get; set; }
        public int IdPointOfSale { get; set; }
        public int IdTable { get; set; }
        public DateTime CreationDate { get; set; }
        public StatusOrderEnum StatusOrder { get; set; }
    }
}
