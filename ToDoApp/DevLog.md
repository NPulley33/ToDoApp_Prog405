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


12/8:
long time no see. Updates while making final project:
- updating tests to make them more seperated & cover more ground. 
- added MVC project
- added repository in MVC project for persistant data
- ToDoViewModel has an extra list of TaskViewModels with Tasks list basically backing it up. This is soley so that the list can have IDs (TaskViewModel is IIdentifiable)

BUGS: repo in ToDoController does not properly update, unsure what to do. Tired both a repo class and simple lists & DI like in class. Doesn't update properly
	(always returns first in the "first or default" method calls, then doesn't recognize any other created instances)

It is 2:30 am and I feel defeated. I wanted to make it so that there was a list of ToDos which could be completed and had a list of 
Tasks that could also be completed. When you clicked on details for a ToDo it would bring you to the list of tasks.
My biggest issue here was I don't know how to send or keep the id for which ToDo you're looking at in the list of Tasks.
Major bug of things just not updating even though I followed my example which works perfectly, that's it.
I'm honestly really dissapointed in myself. 

Class: 
Tests: arrange, act, assert