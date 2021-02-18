using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.Resources;
using Domain.Entities.Registrations.Enums;

namespace Domain.Entities.Registrations.Tests
{
    [TestClass()]
    public class PointOfSaleTests
    {
        [TestMethod()]
        public void PointOfSaleTest()
        {
            PointOfSale pointOfSale = new PointOfSale(1, 1, TypePointOfSaleEnum.SalesCounter);

            Assert.IsTrue((pointOfSale != null && pointOfSale.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.PointOfSale));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Number_Maximum_Length()
        {
            PointOfSale pointOfSale = new PointOfSale(1, 101, TypePointOfSaleEnum.SalesCounter);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Number_Minimum_Length()
        {
            PointOfSale pointOfSale = new PointOfSale(1, 0, TypePointOfSaleEnum.SalesCounter);

            Assert.Fail();
        }
    }
}