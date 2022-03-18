using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FirstProject.Calculator X = new FirstProject.Calculator();
            int z = X.Add(1, 2);
        }
     
    }
}