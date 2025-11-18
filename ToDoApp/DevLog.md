Start of Dev Log: 11/3/25

Structure of To Do App:
A "ToDo" is pretty much just a list of tasks that need to be done. A To Do is completeable as you can have many To Do lists with related tasks
	- You can add, delete, and complete Tasks in a To Do list. You can also complete the To Do list which completes all Tasks

A Task is, well, a task. 
	- A Task needs a name, but a description is optional
	- A Task is completeable
	- You can update the description and due date on a Task

A Dueable Task (yes Jeff, I stole that pun) is a Task that has a due date
	- A dueable task has a due date and can be overdue
	

If making this a whole service app again, should make models/request classes?
I feel like I'm missing something or this isn't robust enough. Maybe I'm just a simple guy who needs a simple To Do app


11/10 

- Added WPF application
- Started work on seperateing view & models
- Models are ToDoApp classes
- added view & model for displaying a task
- started working on a veiw & model for displaying a ToDo/task list & functionality

TODO: refactor tests: break them up

11/17

- Adding commands, adding on to ToDoControl
- Need to Knows:
	- How to dynamically show elements on screen (ex. add a task so add elements to show that task)
	- How to get TaskControl and ToDoControl to talk to each other- want to use TaskControl to display a selected Task from ToDoControl
	- How to add tests for WPF? error when trying to use xUnit