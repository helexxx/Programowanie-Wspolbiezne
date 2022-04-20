using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    internal class ViewModel : RelayCommand
    {
        private ICommand _doSomething;

        public ViewModel(Func<bool> canExecute, Action execute) : base(canExecute, execute)
        {
        }

        public ICommand DoSomethingCommand
        {
            get
            {
                return _doSomething;
            }
        }
    }
}
