using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BallEventArgs : EventArgs
    {
        public readonly MyDataBall Ball;
        public BallEventArgs(MyDataBall ball)
        {
            this.Ball = ball;
        }
    }
}
