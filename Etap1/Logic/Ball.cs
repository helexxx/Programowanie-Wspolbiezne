using System;

namespace Logic
{
    public class Ball
    {
        private double pos_x;
        private double pos_y;
        private int rad_r;
        private double dest_x;
        private double dest_y;

        internal Ball(double x, double y, int radius)
        {
            pos_x = x;
            pos_y = y;
            rad_r = radius;
        }

        public void MoveBall(int maxBorderX,int maxBorderY)
        {
            Random random = new Random();

            this.dest_x = random.Next(0, maxBorderX - this.rad_r);
            this.dest_y = random.Next(0, maxBorderY - this.rad_r);

            double deltaX = dest_x - pos_x;
            double deltaY = dest_y - pos_y;

            double angle = Math.Atan2(deltaY, deltaX);

            // double speed = ?;  how to calculate speed of ball? Is loop speed is enough??

            while(pos_x != dest_x && pos_y != dest_y)
            {
                if (pos_x != dest_x)
                {
                    pos_x += Math.Cos(angle);    // * speed
                }
                if (pos_y != dest_y)
                {
                    pos_y += Math.Sin(angle);    // * speed
                }
            }

            
        }

        public double get_x
        {
            get => pos_x;
            set => pos_x = value;
        }

        public double get_y
        {
            get => pos_y;
            set => pos_y = value;
        }

        public int get_radius
        {
            get => rad_r;
            set
            {
                if (value > 0)
                {
                    rad_r = value;
                }

                else
                {
                    throw new System.ArgumentException();
                }

            }
        }


    }
}