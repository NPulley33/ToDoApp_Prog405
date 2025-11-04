using System.ComponentModel;
using ToDoApp;

namespace ToDoTests
{
    public class UnitTest1
    {
        [Fact]
        public void ToDoAddRemoveTest()
        {
            ToDo list = new ToDo();

            //testing both list.AddTask with all items and Task(name, description, dueDate)
            list.AddTask("new task", "this is a new task");
            Assert.True(list.Tasks.Count == 1);
            Assert.Equal("new task", list.Tasks[0].Name);

            //testing both list.AddTask with just a task and Task(string name)
            ToDoApp.Task t = new ToDoApp.Task("just name task");
            list.AddTask(t);
            Assert.True(list.Tasks.Count == 2);
            Assert.Equal("just name task", list.Tasks[1].Name);
            Assert.Equal(string.Empty, list.Tasks[1].Description);

            //testing adding a dueable task
            list.AddTask("dueable task", DateTime.UtcNow.AddDays(3));
            Assert.Equal("dueable task", list.Tasks[2].Name);
            Assert.True(list.Tasks[2] is DueableTask);

            //testing delete task
            list.DeleteTask("just name task");
            Assert.False(list.ContainsTask("just name task"));
        }

        [Fact]
        public void UpdateTaskTests()
        {
            DueableTask task = new DueableTask("test task", DateTime.UtcNow.AddDays(3));

            //test update description
            Assert.Equal(string.Empty, task.Description);
            task.UpdateDescription("new description");
            Assert.Equal("new description", task.Description);

            //test update due date
            task.UpdateDueDate(DateTime.UtcNow.AddDays(4));
            Assert.True(DateTime.Compare(DateTime.UtcNow.AddDays(3), task.DueDate) < 0);
        }

        [Fact]
        public void CompleteTasksTest()
        { 
            ToDo list = new ToDo();
            list.AddTask("new task 1");
            list.AddTask("new task 2");
            list.AddTask("new task 3");

            list.CompleteTask("new task 2");
            Assert.True(list.Tasks[1].IsCompleted);

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