using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFToDoApp.ViewModels;

namespace WPFToDoApp.Views
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        ToDoApp.Task task;
        public TaskControl()
        {
            InitializeComponent();

            task = new ToDoApp.Task();
            this.DataContext = new TaskViewModel(task);
        }
    }
}
