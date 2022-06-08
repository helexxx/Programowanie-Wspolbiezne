using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallsEventArgs : EventArgs
    {
        public readonly MyDataBall Ball;
        public readonly IList<MyDataBall> Balls;
        public BallsEventArgs(MyDataBall ball, IList<MyDataBall> balls)
        {
            this.Ball = ball;
            this.Balls = balls;
        }
    }

    public abstract class DataAbstractApi
    {
        public event EventHandler<BallsEventArgs>? ballMoved;
        protected IList<MyDataBall>? ballsList;
        protected Random random;
        public Vector2 screenSize { get; protected set; }
        protected DataAbstractApi(Vector2 boardSize)
        {
            this.screenSize = boardSize;
        }
        public abstract IList<MyDataBall> GetBalls();
        public abstract void CreateBalls(int ballsNumber);
        public abstract void StartSimulation();
        public virtual void WhenBallMoved(BallsEventArgs args)
        {
            ballMoved?.Invoke(this, args);
        }

        public static DataAbstractApi? CreateDataApi(Vector2 screenSize)
        {
            return new DataApi(screenSize);
        }

    }

    public class DataApi : DataAbstractApi
    {
        private readonly BallLogs logger = new BallLogs();
        public DataApi(Vector2 screenSize) : base(screenSize)
        {
            this.ballsList = new List<MyDataBall>();
            this.random = new Random();
        }

        public override void StartSimulation()
        {
            foreach (var ball in ballsList)
            {
                ball.Moved += (sender, argv) =>
                {
                    var args = new BallsEventArgs(argv.Ball, new List<MyDataBall>(ballsList));
                    this.WhenBallMoved(args);
                };
                Task.Factory.StartNew(ball.MoveBall);
            }
        }

        public override IList<MyDataBall> GetBalls()
        {
            return ballsList;
        }

        public override void CreateBalls(int ballsNumber)
        {
            var mass = 15;
            for (int i = 0; i < ballsNumber; i++)
            {
                var radius = 40;
                var isPositionFree = false;
                var position = new Vector2(0, 0);
                while (!isPositionFree)
                {
                    position = this.StartPosition(radius);
                    isPositionFree = this.CheckPosition(position, radius);

                }
                Ball ball = new Ball(ballsList.Count, position, radius, mass, this.GenerateDirection());
                ballsList.Add(ball);
            }
        }

        private Vector2 StartPosition(float radius)
		{
			Vector2 point;
			point.X = (float)(random.Next(Convert.ToInt32(screenSize.X - radius * 2))) + radius;
			point.Y = (float)(random.Next(Convert.ToInt32(screenSize.Y - radius * 2))) + radius;
			return point;
		}

        private bool CheckPosition(Vector2 position, float radius)
        {
            foreach (var ball in ballsList)
            {
                if(this.DoBallsCollide(position, radius, ball.pos, ball.radius))
                {
                    return false;
                }
            }
            return true;
        }

        private bool DoBallsCollide(Vector2 pos1, float radius1, Vector2 pos2, float radius2)
        {
            var ballsDistance = (pos1.X - pos2.X) * (pos1.X - pos2.X) + (pos1.Y - pos2.Y) * (pos1.Y - pos2.Y);
            var ballsRadiusDistance = (radius1/2 + radius2/2) * (radius1/2 + radius2/2);
            return ballsDistance <= ballsRadiusDistance;
        }

        public Vector2 GenerateDirection()
        {
            Vector2 direction;
            direction.X = (float)(random.NextDouble() * 10 - 5);
            direction.Y = (float)(random.NextDouble() * 10 - 5);
            return direction;
        }

        public override void WhenBallMoved(BallsEventArgs args)
        {
            logger.AddToLogQueue(args.Ball);
            base.WhenBallMoved(args);
        }
    }
}
