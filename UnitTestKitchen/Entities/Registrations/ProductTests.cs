using Library.Exceptions;
using Library.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Registrations.Tests
{
    [TestClass()]
    public class ProductTests
    {
        const string descriptionWith301 = @"012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
                                            012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
                                            0123456789012345678901234567890123456789012345678901234567890";

        const string productDescription = "Test Product";
        const string kitchenAreaDescription = "Test Kitchen Area";
        private KitchenArea kitchenArea = new KitchenArea(1, kitchenAreaDescription);


        [TestMethod()]
        public void ProductTest()
        {
            Product product = new Product(1, productDescription, 30, kitchenArea);

            Assert.IsTrue((product != null && product.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.Product));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Description_Maximum_Length()
        {
            Product product = new Product(1, descriptionWith301, 30, kitchenArea);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Description_Minimum_Length()
        {
            Product product = new Product(1, string.Empty, 30, kitchenArea);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void TimeToFinish_Maximum_Length()
        {
            Product product = new Product(1, productDescription, 61, kitchenArea);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void TimeToFinish_Minimum_Length()
        {
            Product product = new Product(1, productDescription, 0, kitchenArea);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidParameterException))]
        public void KitchenArea_IsNull()
        {
            Product product = new Product(1, productDescription, 30, null);

            Assert.Fail();
        }
    }
}