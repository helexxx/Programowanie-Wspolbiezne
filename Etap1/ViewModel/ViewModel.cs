using Logic;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ViewModel;

namespace Presentation.ViewModel
{
    public class ViewModelLayer : INotifyPropertyChanged
    {

        public ViewModelLayer()
        {
            MyModel = ModelAbstractApi.CreateAPI();
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            balls_number = 5;
            startButton = "Start";
        }

        private ModelAbstractApi MyModel { get; set; }


        private int balls_number;
        private int height = 400;
        private int width = 600;
        private string startButton;

        public string StartButton
        {
            get => startButton;
            set
            {
                startButton = value;
                RaisePropertyChanged("StartButton");
            }

        }

        public int Width
        {
            get => width;
            set => width = value;
        }


        public int Height
        {
            get => height;
            set => height = value;
        }

        public int NumberOfBalls
        {
            get => balls_number;
            set => balls_number = value;
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public void start()
        {
        }

        public void stop()
        {
   
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}