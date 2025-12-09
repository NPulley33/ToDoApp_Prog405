using System.Security.Permissions;
using ToDoApp;

namespace MVCToDoWebApp.Models
{
    public class ToDoViewModel : ToDo, IIdentifiable
    {
        private static int _id;
        public int Id { get; set; }
        public List<TaskViewModel> TaskViewModels { get; }

        public ToDoViewModel(string name) : base(name) 
        {
            this.Id = _id++;
            TaskViewModels = new List<TaskViewModel>();
        }
        public ToDoViewModel() : this(string.Empty) { }

        public override void AddTask(string name)
        {
            TaskViewModels.Add(new TaskViewModel(name));
            base.AddTask(name);
        }

        public override void AddTask(string name, string description)
        {
            TaskViewModels.Add(new TaskViewModel(name, description));
            base.AddTask(name, description);
        }
    }

    public class ToDoViewModels : IToDoViewModels
    {
        private static List<ToDoViewModel> repo { get; set; }
        public List<ToDoViewModel> Repo {
            get
            {
                if (repo == null) repo = new List<ToDoViewModel>() { new ToDoViewModel("new list") };
                return repo;
            }
        }
    }

    public interface IToDoViewModels
    {
        public List<ToDoViewModel> Repo { get; }
    }
}
