﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Data;

namespace Logic
{
    internal class CollisionHandler
    {
        public static MyDataBall? CheckBallsCollisions(MyDataBall ball, IEnumerable<MyDataBall> ballsList)
        {
            foreach (var ball2 in ballsList)
            {
                if (ReferenceEquals(ball, ball2))
                {
                    continue;
                }

                if (DoBallsCollide(ball, ball2))
                {
                    return ball2;
                }
            }

            return null;
        }

        private static bool DoBallsCollide(MyDataBall ball1, MyDataBall ball2)
        {
            var ball1NextPos = ball1.pos + (Vector2.One * ball1.radius / 2) + ball1.direction;
            var ball2NextPos = ball2.pos + (Vector2.One * ball2.radius / 2) + ball2.direction;
            var ballsDistance = (ball1NextPos.X - ball2NextPos.X) * (ball1NextPos.X - ball2NextPos.X) + (ball1NextPos.Y - ball2NextPos.Y) * (ball1NextPos.Y - ball2NextPos.Y);
            var ballsRDistance = (ball1.radius + ball2.radius) * (ball1.radius + ball2.radius) / 4;
            return ballsDistance <= ballsRDistance;
        }

        public static void CollisionWithWall(MyDataBall ball, Vector2 screenSize)
        {
            var ballNextPos = ball.pos + (Vector2.One * ball.radius / 2) + ball.direction;
            if (ballNextPos.X <= ball.radius / 2 || ballNextPos.X + ball.radius / 2 >= screenSize.X)
            {
                ball.direction = new Vector2(-ball.direction.X, ball.direction.Y);
            }

            if (ballNextPos.Y <= ball.radius / 2 || ballNextPos.Y + ball.radius / 2 >= screenSize.Y)
            {
                ball.direction = new Vector2(ball.direction.X, -ball.direction.Y);
            }
        }

        public static void CollisionWithBalls(MyDataBall ball1, MyDataBall ball2)
        {
            var ball1center = ball1.pos + (Vector2.One * ball1.radius / 2);
            var ball2center = ball2.pos + (Vector2.One * ball2.radius / 2);

            var centerDistancePow1 = Math.Pow((ball1center.X - ball2center.X), 2) + Math.Pow((ball1center.Y - ball2center.Y), 2);
            var massCalculation1 = (2 * ball2.mass / (ball1.mass + ball2.mass));
            var dotProduct1 = Vector2.Dot((ball1.direction - ball2.direction), (ball1center - ball2center));
            var Oi1 = ball1center - ball2center;
            ball1.direction -= massCalculation1 * dotProduct1 / (float)centerDistancePow1 * Oi1;

            var centerDistancePow2 = Math.Pow((ball2center.X - ball1center.X), 2) + Math.Pow((ball2center.Y - ball1center.Y), 2);
            var massCalculation2 = (2 * ball1.mass / (ball1.mass + ball2.mass));
            var dotProduct2 = Vector2.Dot((ball2.direction - ball1.direction), (ball2center - ball1center));
            var Oi2 = ball2center - ball1center;
            ball2.direction -= massCalculation2 * dotProduct2 / (float)centerDistancePow2 * Oi2;
        }
    }
}
