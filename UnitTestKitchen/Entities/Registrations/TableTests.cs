using Library.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Registrations.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void TableTest()
        {
            Table table = new Table(1, 1);

            Assert.IsTrue((table != null && table.Id > 0), string.Format(MessageResource.InvalidTest, FieldResource.Table));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Number_Maximum_Length()
        {
            Table table = new Table(1, 101);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Number_Minimum_Length()
        {
            Table table = new Table(1, 0);

            Assert.Fail();
        }
    }
}