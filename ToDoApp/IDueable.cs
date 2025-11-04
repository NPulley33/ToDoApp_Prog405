using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public interface IDueable
    {
        public DateTime DueDate { get; set; }
        public bool Overdue { get; set; }
    }
}
