using System;
using System.Collections.Generic;

namespace Logic
{
    public class Box
    {
        private readonly int box_width;
        private readonly int box_height;
        private readonly List<Ball> balls_list = new List<Ball>();

        public Box(int width, int height, int balls_number, int ball_radius)
        {
            box_width = width;
            box_height = height;
            generateBalls(balls_number, ball_radius);
        }

        private void generateBalls(int number, int radius)
        {
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {

                int x = r.Next(0, box_width - radius);
                int y = r.Next(0, box_height - radius);
                balls_list.Add(new Ball(x, y, radius));
            }
        }

        public int Width { get => box_width; }
        public int Height { get => box_height; }

        public List<Ball> Balls { get => balls_list; }
    }
}