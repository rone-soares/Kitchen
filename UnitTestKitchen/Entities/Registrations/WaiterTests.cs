using Library.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Registrations.Tests
{
    [TestClass()]
    public class WaiterTests
    {
        const string descriptionWith101 = @"01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

        [TestMethod()]
        public void WaiterTest()
        {
            Waiter waiter = new Waiter(1, "Test Waiter");

            Assert.IsTrue((waiter != null && waiter.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.Waiter));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Name_Maximum_Length()
        {
            Waiter waiter = new Waiter(1, descriptionWith101);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Name_Minimum_Length()
        {
            Waiter waiter = new Waiter(1, string.Empty);

            Assert.Fail();
        }
    }
}