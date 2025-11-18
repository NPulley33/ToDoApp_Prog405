using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;
using ToDoApp;
using WPFToDoApp.ViewModels;

namespace WPFToDoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<ToDoViewModel> ToDos;



    }

}
