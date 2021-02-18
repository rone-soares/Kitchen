using Domain.Entities.Orders.Enums;
using Domain.Entities.Registrations;
using Library.Resources;
using Library.Service;
using System;

namespace Domain.Entities.Orders
{
    public class Order : EntityBase
    {
        public Waiter Waiter { get; protected set; }
        public PointOfSale PointOfSale { get; protected set; }
        public Table Table { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public StatusOrderEnum StatusOrder { get; protected set; }

        public Order()
        { }

        public Order(int id, Waiter waiter, PointOfSale pointOfSale, Table table, 
            DateTime creationDate, StatusOrderEnum statusOrder)
        {
            Id = id;
            CreationDate = ValidationService.SetDate(creationDate, FieldResource.CreationDate);
            StatusOrder = statusOrder;
            SetWaiter(waiter);
            SetPointOfSale(pointOfSale);
            SetTable(table);
        }

        public void SetWaiter(Waiter waiter)
        {
            if (waiter == null)
                ValidationService.ValidateExistRequest(waiter, FieldResource.Waiter);

            Waiter = waiter;
        }

        public void SetPointOfSale(PointOfSale pointOfSale)
        {
            if (pointOfSale == null)
                ValidationService.ValidateExistRequest(pointOfSale, FieldResource.PointOfSale);

            PointOfSale = pointOfSale;
        }

        public void SetTable(Table table)
        {
            if (table == null)
                ValidationService.ValidateExistRequest(table, FieldResource.Table);

            Table = table;
        }

        public void SetStatusOrder(StatusOrderEnum statusOrder)
        {
            StatusOrder = statusOrder;
        }
    }
}
