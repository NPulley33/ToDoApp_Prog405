using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using ToDoApp;

namespace WPFToDoApp.ViewModels
{
    public class ToDoViewModel : BaseViewModel
    {
        private ToDo taskList;
        private ToDoApp.Task newTask;
        public ICommand AddTask { get; set; }
        public ICommand ShowTask { get; set; }

        public string NewTaskName
        {
            get { return newTask.Name; }
            set
            {
                if (NewTaskName != value && value != null)
                {
                    newTask.UpdateName(value);
                    base.RaisePropertyChangedEvent();
                }
            }
        }

        public string NewTaskDescription
        {
            get { return newTask.Description; }
            set
            {
                if (NewTaskDescription != value)
                {
                    if (value is null) newTask.UpdateDescription(string.Empty);
                    else newTask.UpdateDescription(value);
                    base.RaisePropertyChangedEvent();
                }
            }
        }

        //temporary for testing purposes
        public string LastTaskName
        {
            get 
            {
                if (taskList is null || taskList.Tasks.Count == 0) return "no name";
                else return taskList.Tasks[taskList.Tasks.Count - 1].Name;  
            }
        }


        public ToDoViewModel(ToDo taskList)
        { 
            this.taskList = taskList;
            newTask = new ToDoApp.Task();
            this.AddTask = new ToDoCommand(ExecuteCommandAddTask, CanExecuteCommandAddTask);
        }

        //Jeff I'm sorry if this is incorrect I just really prefer in line stuff :(
        private bool CanExecuteCommandAddTask(object parameter) => true;

        private void ExecuteCommandAddTask(object parameter)
        {
            this.taskList.AddTask(newTask.Name, newTask.Description);
            //update sidebar
        }

        private bool CanExecuteCommantdShowTask(object parameter) => true;
        private void ExecuteCommandShowTask(object parameter)
        { 
            //populate TaskControl with selected task
        }


        public class ToDoCommand : ICommand
        {
            public delegate void ICommandOnExecute(object parameter);
            public delegate bool ICommandOnCanExecute(object parameter);

            private ICommandOnExecute _execute;
            private ICommandOnCanExecute _canExecute;

            public ToDoCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
            {
                _execute = onExecuteMethod;
                _canExecute = onCanExecuteMethod;
            }

            #region ICommand Members

            public event EventHandler? CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object? parameter)
            {
                return _canExecute.Invoke(parameter);
            }

            public void Execute(object? parameter)
            {
                _execute.Invoke(parameter);
            }

            #endregion
        }

    }
}
