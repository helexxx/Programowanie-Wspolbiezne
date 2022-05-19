using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Presentation.ViewModel
{
    public class NotifyBall : INotifyPropertyChanged
    {
        private double _X;
        public double X
        {
            get { return _X; }
            set { _X = value; OnPropertyChanged(); }
        }

        private double _Y;
        public double Y
        {
            get { return _Y; }
            set { _Y = value; OnPropertyChanged(); }
        }

        private double _R;
        public double Rad
        {
            get { return _R; }
            set { _R = value; OnPropertyChanged(); }
        }

        public NotifyBall()
        {
            var position = new Vector2(0, 0);
            X = (double)position.X;
            Y = (double)position.Y;
            Rad = 0;
        }

        public void ChangePosition(Vector2 position)
        {
            X = position.X;
            Y = position.Y;
        }

        public void ChangeRadius(float R)
        {
            Rad = R;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
