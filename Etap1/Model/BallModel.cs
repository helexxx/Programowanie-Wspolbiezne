using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        public BallModel(Ball ball)
        {
            ball.PropertyChanged += OnPropertyChanged;
            X_Center = ball.pos_x;
            Y_Center = ball.pos_y;
            Radius = ball.rad_r;
        }

        private double x_center;
        private double y_center;
        private int radius;

        public int CenterTransform { get { return -1 * Radius; } }
        public int Diameter { get => 2 * Radius; }
        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                RaisePropertyChanged("Radius");
            }

        }
        public double X_Center
        {
            get => x_center;
            set
            {
                x_center = value;
                RaisePropertyChanged("X_Center");
            }
        }
        public double Y_Center
        {
            get => y_center;
            set
            {
                y_center = value;
                RaisePropertyChanged("Y_Center");

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Ball b = (Ball)sender;

            switch (e.PropertyName)
            {
                case "X":
                    X_Center = b.dest_x;
                    break;
                case "Y":
                    Y_Center = b.dest_y;
                    break;
            }
        }
    }
}