using ToDoApp;

namespace MVCToDoWebApp.Models
{
    public class TaskViewModel: ToDoApp.Task, IIdentifiable
    {
        private static int _id;
        public int Id { get; set; }

        public TaskViewModel(string name) : base(name) { this.Id = _id++; }
        public TaskViewModel() : base() { this.Id = _id++; }

        public TaskViewModel(string name, string description) : this(name)
        { 
            Description = description;
        }
    }
}
