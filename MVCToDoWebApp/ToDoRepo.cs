using ToDoApp;
using MVCToDoWebApp.Models;

namespace MVCToDoWebApp
{
    public class ToDoRepo : IRepository<ToDoViewModel>
    {
        public List<ToDoViewModel> database { get; set; }

        public ToDoRepo() : this(new List<ToDoViewModel> { new ToDoViewModel("new list") }) { }

        public ToDoRepo(List<ToDoViewModel> data)
        { 
            database = data;
        }

        public void Add(ToDoViewModel item)
        {
            database.Add(item);
        }

        public void Remove(ToDoViewModel item)
        {
            database.Remove(item);
        }
    }
}
