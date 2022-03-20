using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddition()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            int z = X.Add(1, 2);
            Assert.AreEqual(3, z);
        }

        [TestMethod]
        public void TestSubstraction()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            int z = X.Sub(4, 2);
            Assert.AreEqual(z, 2);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            int z = X.Multi(4, 2);
            Assert.AreEqual(z,8);
        }

        [TestMethod]
        public void TestDivision()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            double z = X.Div(4, 2);
            Assert.AreEqual(z, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestDivisionNegative()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            X.Div(4, 0);
        }

    }
}