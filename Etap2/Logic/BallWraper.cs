using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Data;

namespace Logic
{
    public interface MyLogicBall
    {
        int id { get; }
        Vector2 position { get; }
        float radius { get; }
        float mass { get; }
    }

    internal class BallWraper : MyLogicBall
    {
        private readonly MyDataBall ball;

        public BallWraper(MyDataBall ball)
        {
            this.ball = ball;
        }

        public int id { get => ball.id; }
        public Vector2 position { get => ball.pos; }
        public float radius { get => ball.radius; }
        public float mass { get => ball.mass; }
    }
}
