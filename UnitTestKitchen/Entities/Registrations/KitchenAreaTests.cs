using Library.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Registrations.Tests
{
    [TestClass()]
    public class KitchenAreaTests
    {
        [TestMethod()]
        public void KitchenAreaTest()
        {
            KitchenArea kitchenArea = new KitchenArea(1, "Test Kitchen Area");

            Assert.IsTrue((kitchenArea != null && kitchenArea.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.KitchenArea));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Description_Maximum_Length()
        {
            KitchenArea kitchenArea = new KitchenArea(1, "012345678901234567890123456789012345678901234567890123456789");

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Description_Minimum_Length()
        {
            KitchenArea kitchenArea = new KitchenArea(1, string.Empty);

            Assert.Fail();
        }
    }
}