using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using ToDoApp;

namespace ToDoTests
{
    //unit test todo & unit test task
    //Following AAA test framework (arrange, act, assert)
    public class ToDoAppTests
    {
        [Fact]
        public void CreateTaskWithNameAndDesciptionTest()
        { 
            ToDoApp.Task t = new ToDoApp.Task("name of task", "this is a description");

            Assert.Equal("name of task", t.Name);
            Assert.Equal("this is a description", t.Description);
        }

        [Fact]
        public void CreateTaskWithNameTest()
        {
            ToDoApp.Task t = new ToDoApp.Task("name of task");

            Assert.Equal("name of task", t.Name);
            Assert.Equal(string.Empty, t.Description);
        }

        [Fact]
        public void CreateTaskNoNameTest()
        {
            ToDoApp.Task t = new ToDoApp.Task();

            Assert.Equal("no name", t.Name);
            Assert.Equal(string.Empty, t.Description);
        }

        [Fact]
        public void CreateDueableTask()
        {
            DueableTask t = new DueableTask("new task name", DateTime.UtcNow.AddDays(3));

            Assert.True(t is DueableTask);
            Assert.Equal("new task name", t.Name);
            Assert.Equal(string.Empty, t.Description);
        }

        [Fact]
        [Category("To Do")]
        public void AddTaskViaStringParametersTest()
        {
            ToDo list = new ToDo();

            //testing both list.AddTask with all items and Task(name, description, dueDate)
            list.AddTask("new task", "this is a new task");

            Assert.Single(list.Tasks);
            Assert.True(list.ContainsTask("new task"));
        }

        [Fact]
        public void AddTaskViaTaskParemeterTest()
        {
            ToDo list = new ToDo();

            ToDoApp.Task t = new ToDoApp.Task("new task");
            list.AddTask(t);

            Assert.Single(list.Tasks);
            Assert.True(list.ContainsTask("new task"));
        }

        [Fact]
        public void AddDuableTaskViaParametersTest()
        {
            ToDo list = new ToDo();

            list.AddTask("dueable task", DateTime.UtcNow.AddDays(3));

            Assert.Equal("dueable task", list.Tasks[0].Name);
            Assert.True(list.Tasks[0] is DueableTask);
        }

        [Fact]
        public void AddDuableTaskViaGivenTaskParameterTest()
        {
            ToDo list = new ToDo();
            DueableTask t = new DueableTask("dueable task", DateTime.UtcNow.AddDays(3));

            list.AddTask(t);

            Assert.Equal("dueable task", list.Tasks[0].Name);
            Assert.True(list.Tasks[0] is DueableTask);
        }

        [Fact]
        public void RemoveTaskTest()
        {
            ToDo list = new ToDo();
            list.AddTask("new task");

            list.DeleteTask("new task");

            Assert.False(list.ContainsTask("new task"));
        }

        [Fact]
        public void UpdateTaskDescriptionTest()
        {
            DueableTask task = new DueableTask("test task", "start desctiption", DateTime.UtcNow.AddDays(3));

            task.UpdateDescription("new description");

            Assert.Equal("new description", task.Description);
        }

        [Fact]
        public void UpdateTaskDueDateTest()
        {
            DueableTask task = new DueableTask("test task", DateTime.UtcNow.AddDays(3));

            task.UpdateDueDate(DateTime.UtcNow.AddDays(4));

            Assert.True(DateTime.Compare(DateTime.UtcNow.AddDays(3), task.DueDate) < 0);
        }

        [Fact]
        public void CompleteSingleTaskInTodoTest()
        { 
            ToDo list = new ToDo();
            list.AddTask("new task 1");
            list.AddTask("new task 2");
            list.AddTask("new task 3");

            list.CompleteTask("new task 2");
            Assert.True(list.Tasks[1].IsCompleted);
        }

        [Fact]
        public void CompleteAllTasksInTodoTest()
        {
            ToDo list = new ToDo();
            list.AddTask("new task 1");
            list.AddTask("new task 2");
            list.AddTask("new task 3");

            list.Complete();

            Assert.True(list.IsCompleted);
            foreach (var task in list.Tasks)
            {
                Assert.True(task.IsCompleted);
            }
        }

        [Fact]
        public void OverdueTaskTest()
        { 
            DueableTask task = new DueableTask("test task", DateTime.MinValue);
            task.CheckOverdue();
            Assert.True(task.Overdue);
        }
    }
}