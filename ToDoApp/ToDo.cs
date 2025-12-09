using Microsoft.VisualBasic;

namespace ToDoApp
{
    public class ToDo : ICompleteable
    {
        public string Name { get; set; }
        public List<Task> Tasks;
        public bool IsCompleted { get; set; }

        public ToDo() 
        { 
            Tasks = new List<Task>();
        }

        public ToDo(string name) : this()
        { 
            this.Name = name;
        }

        public virtual void AddTask(string name, string description)
        {
            Tasks.Add(new Task(name, description));
        }

        public virtual void AddTask(string name) => Tasks.Add(new Task(name));

        public virtual void AddTask(Task task) => Tasks.Add(task);

        public void AddTask(string name, string description, DateTime dueDate)
        {
            Tasks.Add(new DueableTask(name, description, dueDate));
        }

        public void AddTask(string name, DateTime dueDate)
        {
            Tasks.Add(new DueableTask(name, dueDate));
        }

        public void AddTask(DueableTask task) => Tasks.Add(task);



        public virtual void DeleteTask(string taskName)
        {
            foreach (Task t in Tasks)
            {
                if (t.Name == taskName)
                {
                    Tasks.Remove(t);
                    break;
                }
            }
        }

        public virtual void CompleteTask(string taskName)
        {
            foreach (Task t in Tasks)
            {
                if (t.Name == taskName)
                { 
                    t.Complete();
                    //Tasks.Remove(t);
                    break;
                }
            }
        }

        //i like having this function as sometimes i will forget to mark things complete
        public void Complete()
        {
            foreach (Task t in Tasks)
            { 
                t.Complete();
            }
            IsCompleted = true;
        }

        //for testing, mostly
        public bool ContainsTask(string taskName)
        {
            foreach (Task t in Tasks)
            {
                if (t.Name == taskName) return true;
            }
            return false;
        }

        public void UpdateName(string newName)
        {
            if (!IsCompleted) Name = newName;
        }

        //could add:
        /**
         * star/mark task
         * categorize task (enum?)
         * stages of finished (ex. in progress)
         */
    }
}
