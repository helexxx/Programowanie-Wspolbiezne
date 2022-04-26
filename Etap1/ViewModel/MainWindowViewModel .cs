using Logic;
using Model;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ViewModel;

namespace MainWindowViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        #region public API

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Start = new RelayCommand(() => StartHandler());
            Stop = new RelayCommand(() => StopHandler());
        }

        public IList<object> CirclesCollection
        {
            get
            {
                return b_CirclesCollection;
            }
            set
            {
                if (value.Equals(b_CirclesCollection))
                    return;
                RaisePropertyChanged("CirclesCollection");
            }
        }

        public int Radious
        {
            get
            {
                return ModelLayer.Radius;
            }
        }

        public int Count
        {
            get
            {
                return ModelLayer.Count;
            }
            set
            {
                if (value.Equals(ModelLayer.Count))
                    return;
                ModelLayer.Count = value;
                RaisePropertyChanged("Count");
            }
        }

        public ObservableCollection<Ball> Ball
        {
            get
            {
                return ModelLayer.Balls;
            }
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        private void StartHandler()
        {
            ModelLayer.StartSimulation();
        }

        private void StopHandler()
        {
            ModelLayer.StopSimulation();
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

        #endregion private

    }
}