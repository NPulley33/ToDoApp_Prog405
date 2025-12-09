using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCToDoWebApp;
using MVCToDoWebApp.Controllers;
using MVCToDoWebApp.Models;

namespace ToDoTests
{
    public class MVCTests
    {

        [Fact]
        public void IDIncreaseTest()
        {
            ToDoViewModel vm1 = new ToDoViewModel();
            Assert.Equal(0, vm1.Id);

            ToDoViewModel vm2 = new ToDoViewModel();

            Assert.Equal(1, vm2.Id);
        }

        [Fact]
        public void ToDoViewModelRepoNotNullTest()
        { 
            ToDoViewModels vms = new ToDoViewModels();

            Assert.NotNull(vms.Repo);
        }

        [Fact]
        public void ToDoTaskViewModelMatchesTasksTest()
        { 
            ToDoViewModel vm = new ToDoViewModel();

            vm.AddTask("new task");
            vm.AddTask("new task 2");
            vm.AddTask("new task 3");

            Assert.Equal(vm.TaskViewModels.Count, vm.Tasks.Count);
        }
    }
}
