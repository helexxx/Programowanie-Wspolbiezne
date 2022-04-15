using Data;

namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateAPI(DataAPI dataAPI)
        {
            return new LogicLayer(dataAPI);
        }

        public abstract Ball CreateBall(int x, int y, int radius);
        public abstract Box CreateBox(int height, int width, int balls_number, int ball_radius);


        public class LogicLayer : LogicAPI
        {
            public LogicLayer(DataAPI dataAPI)
            {
                dataLayer1 = dataAPI;
            }

            public override Ball CreateBall(int x, int y, int radius)
            {
                return new Ball(x, y, radius);
            }

            public override Box CreateBox(int height, int width, int balls_number, int ball_radius)
            {
                return new Box(height, width, balls_number, ball_radius);
            }

            private readonly DataAPI dataLayer1;
        }




    }
}