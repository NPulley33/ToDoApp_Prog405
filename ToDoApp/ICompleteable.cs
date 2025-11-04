using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal interface ICompleteable
    {
        public bool IsCompleted { get; set; }

        public void Complete();
    }
}
