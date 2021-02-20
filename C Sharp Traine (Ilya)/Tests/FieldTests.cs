using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using XOGame;
namespace Tests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void TestConstructors()
        {
            Field field = new Field();
            Assert.AreEqual<int>(3, field.Rows);
            Assert.AreEqual<int>(3, field.Columns);
            Assert.AreEqual<string>("_ _ _\n_ _ _\n_ _ _", field.ToString());
            field.Rows = 1;
            field.Columns = 3;
            Assert.AreEqual<string>("_ _ _", field.ToString());
        }
    }
}
