using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logic
{
    public class Box
    {
        private readonly int box_width;
        private readonly int box_height;
        private ObservableCollection<Ball> balls_list = new ObservableCollection<Ball>();

        internal Box()
        {
            box_width = 400;
            box_height = 400;
        }

        internal void generateBalls(int number, int radius)
        {
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {
                double x = r.Next(0, box_width - radius);
                double y = r.Next(0, box_height - radius);
                balls_list.Add(new Ball(x, y, radius));
            }
        }

        internal void MoveBalls()
        {
            while (true)
            {
                foreach (Ball ball in balls_list)
                {
                    ball.MoveBall(box_width, box_height);
                }
            }
        }

        public int Width { get => box_width; }
        public int Height { get => box_height; }

        public ObservableCollection<Ball> Balls { get => balls_list; }
    }
}