using NUnit.Framework;
using Data;
using System.Collections.Generic;

namespace DataTests
{
    internal class DataApiTest
    {
        DataApi dataApi;
        [SetUp]
        public void Setup()
        {
            dataApi = new DataApi(new System.Numerics.Vector2(900, 900));
            dataApi.CreateBalls(13);
        }

        [Test]
        public void GetBallsTest()
        {
            Assert.AreEqual(13, dataApi.GetBalls().Count);
        }   
    }
}