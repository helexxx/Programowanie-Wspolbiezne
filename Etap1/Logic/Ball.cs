using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        public double pos_x;
        public double pos_y;
        public int rad_r;
        public double dest_x;
        public double dest_y;

       internal Ball(Box box)
        {
            Random random = new Random();

            this.rad_r = 3;

            this.pos_x = random.Next(0, box.Width - this.rad_r);
            this.pos_y = random.Next(0, box.Height - this.rad_r);
        }
        internal Ball(double x, double y, int radius)
        {
            pos_x = x;
            pos_y = y;
            rad_r = radius;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void MoveBall(int maxBorderX,int maxBorderY)
        {
            Random random = new Random();

            this.dest_x = random.Next(0, maxBorderX - this.rad_r);
            this.dest_y = random.Next(0, maxBorderY - this.rad_r);

            double deltaX = dest_x - pos_x;
            double deltaY = dest_y - pos_y;

            double angle = Math.Atan2(deltaY, deltaX);

            // double speed = ?;  how to calculate speed of ball? Is loop speed is enough??

                if (pos_x != dest_x)
                {
                    pos_x += Math.Cos(angle);    // * speed
                }
                if (pos_y != dest_y)
                {
                    pos_y += Math.Sin(angle);    // * speed
                }
    
            RaisePropertyChanged(nameof(PosX));
            RaisePropertyChanged(nameof(PosY));

        }

        public double PosX
        {
            get => pos_x;
            set => pos_x = value;
        }

        public double PosY
        {
            get => pos_y;
            set => pos_y = value;
        }

        public int Radius
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
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //  public Action<object, PropertyChangedEventArgs> PropertyChanged { get; set; }
    }
}