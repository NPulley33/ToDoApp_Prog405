using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;
using ToDoApp;
using WPFToDoApp.ViewModels;
using ToDoApp;

namespace WPFToDoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<ICompleteable> ToDos;

        //assign observabble collection to ToDoControl's ToDo list?
        //otherwise can also be just a list of Tasks?

    }

}
