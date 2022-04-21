using Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModel : ViewModelBase
    {

        public ViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public ViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            ButtomClick = new RelayCommand(() => ClickHandler());
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
                return b_Radious;
            }
            set
            {
                if (value.Equals(b_Radious))
                    return;
                b_Radious = value;
                RaisePropertyChanged("Radious");
            }
        }

        public ICommand ButtomClick { get; set; }

        private void ClickHandler()
        {
            // do something usefull
        }

        private IList<object> b_CirclesCollection;
        private int b_Radious;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

    }
}