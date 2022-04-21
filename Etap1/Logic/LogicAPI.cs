using Data;

namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateAPI(DataAPI dataAPI)
        {
            return new LogicLayer(dataAPI);
        }

        public abstract Ball CreateBall(double x, double y, int radius);
        public abstract Box CreateBox();

        public abstract void Simulation(Box box);

        public class LogicLayer : LogicAPI
        {
            public LogicLayer(DataAPI dataAPI)
            {
                dataLayer1 = dataAPI;
            }

            public override Ball CreateBall(double x, double y, int radius)
            {
                return new Ball(x, y, radius);
            }

            public override Box CreateBox()
            {
                return new Box();
            }

            public override void Simulation(Box box)
            {
                box.MoveBalls();
            }

            private readonly DataAPI dataLayer1;
        }




    }
}