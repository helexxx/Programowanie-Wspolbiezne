using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
	public class LogicBallEventArgs : EventArgs
	{
		public readonly MyLogicBall Ball;
		public LogicBallEventArgs(MyLogicBall ball)
		{
			this.Ball = ball;
		}
	}
}
