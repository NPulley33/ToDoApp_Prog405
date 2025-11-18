using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFToDoApp.ViewModels
{
    public abstract class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        protected void RaisePropertyChangedEvent([CallerMemberName] string? propertyName = null)
        {
            if (PropertyChanged == null)
            {
                throw new InvalidOperationException("property changed is null");
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BasicCommand : ICommand
    {
        private Action commandAction;
        private bool canExecute;

        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        public BasicCommand(Action action)
        {
            commandAction = action;
            canExecute = true;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute; //probably should't always return true but for now allow all ICommands to execute
        }

        public void Execute(object? parameter)
        {
            commandAction();
        }
    }
}
