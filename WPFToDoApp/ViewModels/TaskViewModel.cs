using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoApp;

namespace WPFToDoApp.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {

        private ToDoApp.Task task;

        public TaskViewModel(ToDoApp.Task task)
        { 
            this.task = task;
        }

        public string Name
        {
            get { return task.Name; }
        }

        public string Description
        { 
            get { return task.Description; }
            set
            {
                if (Description != value)
                { 
                    task.UpdateDescription(value);
                    base.RaisePropertyChangedEvent();
                }
            }
        }
    }
}
