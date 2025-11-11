using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp;

namespace WPFToDoApp.ViewModels
{
    public class ToDoViewModel
    {
        private ToDo taskList;

        public ToDoViewModel(ToDo taskList)
        { 
            this.taskList = taskList; 
        }

    }
}
