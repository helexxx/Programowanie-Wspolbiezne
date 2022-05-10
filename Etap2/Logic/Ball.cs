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
        private double speed_x;
        private double speed_y;
        private bool alive;

        internal Ball(double x, double y, int radius)
        {
            pos_x = x;
            pos_y = y;
            rad_r = radius;
            this.speed_x = (double)4;
            this.speed_y = (double)4;

            alive = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void MoveBall(int maxBorderX,int maxBorderY)
        {
            double tmp_x, tmp_y;

            tmp_x = PosX + XSpeed;
            tmp_y = PosY + YSpeed;
            this.CheckX(tmp_x);
            this.CheckY(tmp_y);

            RaisePropertyChanged(nameof(PosX));
            RaisePropertyChanged(nameof(PosY));

        }

        public void CheckX(double tmp_x)
        {
            if (tmp_x >= 400 - Radius * 2)
            {
                PosX = 400 - Radius * 2;
                XSpeed *= -1;
            }
            else if (tmp_x <= 0)
            {
                PosX = 0;
                XSpeed *= -1;
            }
            else
            {
                PosX = PosX + XSpeed;
            }
        }

        public void CheckY(double tmp_y)
        {
            if (tmp_y + Radius * 2 >= 400)
            {
                PosY = 400 - Radius * 2;
                YSpeed *= -1;
            }
            else if (tmp_y <= 0)
            {
                PosY = 0;
                YSpeed *= -1;
            }
            else
            {
                PosY = PosY + YSpeed;
            }
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

        public double XSpeed
        {
            get => this.speed_x;
            set => this.speed_x = value;
        }

        public double YSpeed
        {
            get => this.speed_y;
            set => this.speed_y = value;
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

        public bool Alive { get => alive; set => alive = value; }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //  public Action<object, PropertyChangedEventArgs> PropertyChanged { get; set; }
    }
}