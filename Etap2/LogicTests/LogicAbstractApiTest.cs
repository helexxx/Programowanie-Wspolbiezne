using NUnit.Framework;
using Logic;
using System.Numerics;
using Data;

namespace LogicTests
{
    public class LogicApiTest
    {
        DataApi dataApi;
        LogicAbstractApi abstractLogic;
        LogicApi logic;

        [SetUp]
        public void Setup()
        {
            dataApi = new DataApi(new Vector2(800, 500));
            abstractLogic = LogicAbstractApi.CreateApi(new Vector2(800, 500));
            logic = new LogicApi(dataApi);
            logic.CreateBalls(10);
        }

        [Test]
        public void CreateApiTest()
        {
            Assert.AreEqual(10, dataApi.GetBalls().Count);
            logic.StartSimulation();
        }

        [Test]
        public void CreateAbstractApiTest()
        {
            abstractLogic.StartSimulation();
        }
    }
}