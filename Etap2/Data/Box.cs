using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;


namespace Data
{
    internal class Box
    {
        private readonly int box_width = 400;
        private readonly int box_height = 400;
        private ObservableCollection<Ball> balls = new ObservableCollection<Ball>();

        internal void generateBalls(int number, int radius)
        {
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {
                double x = r.Next(0, box_width - radius);
                double y = r.Next(0, box_height - radius);
                balls.Add(new Ball(x, y, radius));
            }
        }

        internal void MoveBalls()
        {
            while (true)
            {
                foreach (Ball ball in balls)
                {
                    ball.MoveBall(box_width, box_height);
                }
            }
        }

        public int Width { get => box_width; }
        public int Height { get => box_height; }

        public  ObservableCollection<Ball> Balls { get => balls; }

    }
}