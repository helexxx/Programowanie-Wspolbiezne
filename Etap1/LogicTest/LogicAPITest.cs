using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.LogicTest

{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void BallTest() {
        
            LogicAPI LogicApi = LogicAPI.CreateAPI();
            Box box = LogicApi.CreateBox();
            LogicApi.CreateBalls(30, 5, box);

            foreach (Ball ball in box.Balls)
            {
                Assert.AreEqual(5, ball.rad_r);
                Assert.IsTrue(ball.PosX >= 0 && ball.PosX <= box.Height - ball.Radius);
                Assert.IsTrue(ball.PosY >= 0 && ball.PosY <= box.Width - ball.Radius);
            }
        }

        [TestMethod]
        public void BoxTest()
        {
            LogicAPI LogicApi = LogicAPI.CreateAPI();
            Box box = LogicApi.CreateBox();
            LogicApi.CreateBalls(3, 5, box);

            Assert.AreEqual(box.Height, 400);
            Assert.AreEqual(box.Width, 400);
            Assert.AreEqual(box.Balls.Count, 3);
        }

        [TestMethod]
        public void StartStopMovementTest()
        {

            LogicAPI LogicApi = LogicAPI.CreateAPI();
            Box box = LogicApi.CreateBox();
            LogicApi.CreateBalls(3, 5, box);


            LogicApi.StartSimulation(box);
            foreach (Ball ball in box.Balls)
            {
                Assert.AreEqual(true,ball.Alive);
            }

            LogicApi.StopSimulation(box);
            foreach (Ball ball in box.Balls)
            {
                Assert.AreEqual(false, ball.Alive);
            }
        }
    }

}