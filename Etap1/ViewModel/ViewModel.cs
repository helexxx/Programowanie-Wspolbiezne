using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
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

    public class Command : ICommand
    {
       public event EventHandler CanExecuteChanged;

       private readonly Action move_Execute;
        private readonly Func<bool> move_CanExecute;

        //
        // Podsumowanie:
        //     Defines the method that determines whether the command can execute in its current
        //     state.
        //
        // Parametry:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        //
        // Zwraca:
        //     true if this command can be executed; otherwise, false.
        public bool CanExecute(object parameter)
        {
            if(parameter == null)
            { 
                return true; 
            }
           return this.move_CanExecute();
        }
        //
        // Podsumowanie:
        //     Defines the method to be called when the command is invoked.
        //
        // Parametry:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        public void Execute(object parameter)
        {
            this.move_Execute();
        }
    }
}
