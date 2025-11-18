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
using ToDoApp;
using WPFToDoApp.ViewModels;

namespace WPFToDoApp.Views
{
    /// <summary>
    /// Interaction logic for ToDoControl.xaml
    /// </summary>
    public partial class ToDoControl : UserControl
    {
        ToDo taskList;

        public ToDoControl()
        {
            InitializeComponent();
            taskList = new ToDo();
            this.DataContext = new ToDoViewModel(taskList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
