namespace ToDoApp
{
    public class Task : ICompleteable
    {
        public string Name { get; protected set; }

        //can have an empty desctiption
        public string Description { get; protected set; }

        public bool IsCompleted { get; set; }   

        public Task(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }

        //update this like below
        public Task(string name)
        { 
            this.Name= name;
            this.Description = string.Empty;
        }

        public Task() : this("no name") { }

        public void UpdateDescription(string newDescription)
        { 
            if (!IsCompleted) Description = newDescription;
        }

        public void Complete()
        { 
            IsCompleted = true;
        }

        public void UpdateName(string newName)
        { 
            if (!IsCompleted) Name = newName;
        }

    }
}
