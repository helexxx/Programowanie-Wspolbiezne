using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class RelayCommand : ICommand
    {
       public event EventHandler CanExecuteChanged;

       private readonly Action move_Execute;
       private readonly Func<bool> move_CanExecute;

        public RelayCommand(Func<bool> canExecute, Action execute)
        {
            move_CanExecute = canExecute;
            move_Execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if(parameter == null)
            { 
                return true; 
            }
           return this.move_CanExecute();
        }

        public void Execute(object parameter)
        {
            this.move_Execute();
        }
    }
}
