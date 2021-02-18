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
    public class OrderItemTests
    {
        private Order order = new Order(1, new Waiter(1, "Test Waiter"), new PointOfSale(1, 1, TypePointOfSaleEnum.SalesCounter), new Table(1, 1), DateTime.Today, StatusOrderEnum.Open);
        private Product product = new Product(1, "Test Product", 30, new KitchenArea(1, "Test Kitchen Area"));


        [TestMethod()]
        public void OrderItemTest()
        {
            OrderItem orderItem = new OrderItem(1, order, product, 1);

            Assert.IsTrue((orderItem != null && orderItem.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.OrderItem));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Amount_Maximum_Length()
        {
            OrderItem orderItem = new OrderItem(1, order, product, 101);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Amount_Minimum_Length()
        {
            OrderItem orderItem = new OrderItem(1, order, product, 0);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Order_IsNull()
        {
            OrderItem orderItem = new OrderItem(1, null, product, 1);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Product_IsNull()
        {
            OrderItem orderItem = new OrderItem(1, order, null, 1);

            Assert.Fail();
        }
    }
}