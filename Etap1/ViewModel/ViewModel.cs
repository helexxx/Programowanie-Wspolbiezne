using Model;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModel : ViewModelBase
    {

        private int b_Radious;
        private int _width;
        private int _height;

        private ModelAbstractApi modelApi = ModelAbstractApi.CreateApi();

        public ViewModel(ModelAbstractApi modelAbstractApi)
        {
            modelApi = modelAbstractApi;
            b_Radious = modelApi.Radius;
            _height = modelApi.Height;
            _width = modelApi.Width;
            ButtonClick = new RelayCommand(() => ClickHandler());
        }
        public ICommand ButtonClick { get; set; }

        private void ClickHandler()
        {
            modelApi.BeginMove();
        }
    }
}