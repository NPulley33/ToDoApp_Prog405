using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class DueableTask : Task, IDueable
    {
        public DateTime DueDate { get; set; }
        public bool Overdue { get; set; }

        public DueableTask(string name, string description, DateTime dueDate) : base(name, description) 
            { this.DueDate = dueDate; }

        public DueableTask(string name, DateTime dueDate) : base(name) { this.DueDate = dueDate; }

        public void UpdateDueDate(DateTime newDueDate)
        {
            if (!IsCompleted) DueDate = newDueDate;
        }

        public void CheckOverdue()
        {
            if (DateTime.Compare(DueDate, DateTime.UtcNow) <= 0) Overdue = true;
        }
    }
}
