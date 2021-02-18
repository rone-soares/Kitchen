using Domain.Entities.Orders.Enums;
using Domain.Entities.Registrations;
using Domain.Entities.Registrations.Enums;
using Library.Exceptions;
using Library.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Orders.Tests
{
    [TestClass()]
    public class OrderTests
    {
        private Waiter waiter = new Waiter(1, "Test Waiter");
        private PointOfSale pointOfSale = new PointOfSale(1, 1, TypePointOfSaleEnum.SalesCounter);
        private Table table = new Table(1, 1);

        [TestMethod()]
        public void OrderTest()
        {
            Order order = new Order(1, waiter, pointOfSale, table, DateTime.Today, StatusOrderEnum.Open);

            Assert.IsTrue((order != null && order.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.Order));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void CreationDate_IsNull()
        {
            Order order = new Order(1, waiter, pointOfSale, table, DateTime.MinValue, StatusOrderEnum.Open);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Waiter_IsNull()
        {
            Order order = new Order(1, null, pointOfSale, table, DateTime.Today, StatusOrderEnum.Open);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void PointOfSale_IsNull()
        {
            Order order = new Order(1, waiter, null, table, DateTime.Today, StatusOrderEnum.Open);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Table_IsNull()
        {
            Order order = new Order(1, waiter, pointOfSale, null, DateTime.Today, StatusOrderEnum.Open);

            Assert.Fail();
        }
    }
}