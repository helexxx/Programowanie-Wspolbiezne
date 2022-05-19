using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{
	public abstract class LogicAbstractApi
	{
		public event EventHandler<LogicBallEventArgs>? BallMoved;
		public virtual void WhenBallMoved(LogicBallEventArgs args)
		{
			BallMoved?.Invoke(this, args);
		}
		public abstract void StartSimulation();
		public abstract void CreateBalls(int ballsNumber);
		public static LogicAbstractApi CreateApi(Vector2 screenSize, DataAbstractApi? data = default(DataAbstractApi))
		{
			if(data == null)
            {
				data = DataAbstractApi.CreateDataApi(screenSize);
            }
			return new LogicApi(data);
		}
	}

	public class LogicApi : LogicAbstractApi
	{
		private object locker = new object();
		protected readonly DataAbstractApi? data;
		public LogicApi(DataAbstractApi data)
		{
			this.data = data;
		}

        public override void StartSimulation()
        {
			data.ballMoved += WhenDataBallMoved;
			data.StartSimulation();
        }

        public override void CreateBalls(int ballsNumber)
		{
			data.CreateBalls(ballsNumber);
		}

		private void WhenDataBallMoved(object _, Data.BallsEventArgs args)
		{
			this.WhenBallMoved(new LogicBallEventArgs(new BallWraper(args.Ball)));

			lock (locker)
			{
				var collidedBall = CollisionHandler.CheckBallsCollisions(args.Ball, args.Balls);
				if (collidedBall != null)
				{
					CollisionHandler.CollisionWithBalls(args.Ball, collidedBall);
				}
			}
			

			CollisionHandler.CollisionWithWall(args.Ball, data.screenSize);
		}
	}
}