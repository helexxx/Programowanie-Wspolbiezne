using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.LogicTest

{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void BallBoxTest() {
        
            LogicAPI LogicApi = LogicAPI.CreateAPI();
            Box box = LogicApi.CreateBox();
            LogicApi.CreateBalls(3, 5, box);


            Assert.AreEqual(box.Height, 400);
            Assert.AreEqual(box.Width, 400);
            Assert.AreEqual(box.Balls.Count, 3);

            foreach (Ball ball in box.Balls)
            {
                Assert.AreEqual(5, ball.rad_r);
                //Assert.IsTrue(ball.pos_x >= ball.rad_r && ball.pos_x <= (box.Width - ball.rad_r));
                //Assert.IsTrue(ball.pos_y >= ball.rad_r && ball.pos_y <= (box.Height - ball.rad_r));
            }
        }

        [TestMethod]
        public void MovementTest()
        {

            LogicAPI LogicApi = LogicAPI.CreateAPI();
            Box box = LogicApi.CreateBox();
            LogicApi.CreateBalls(3, 5, box);

            double tmp_x = box.Balls[0].PosX;
            double tmp_y = box.Balls[0].PosY;

            LogicApi.StartSimulation(box);

            Assert.AreNotEqual(box.Balls[0].PosX, tmp_x);
            Assert.AreNotEqual(box.Balls[0].PosY, tmp_y);

        }
    }

}