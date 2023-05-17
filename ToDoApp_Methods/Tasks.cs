using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp_Methods
{
    public  class Tasks
    {
        public int ListId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string PriorityLevel { get; set; }
        public bool IsComplete { get; set; }
        public Guid UserId { get; set; }

        public Tasks AddTask(List<Tasks> TodoList, User currentUser, int listid, string title, string description, DateTime duedate, string prioritylevel)
        {
            Tasks newTask = new Tasks {ListId = listid, Title = title, Description = description, DueDate = duedate, PriorityLevel = prioritylevel };
            currentUser.TodoList.Add(newTask);
            return newTask;
        }
    }
}
