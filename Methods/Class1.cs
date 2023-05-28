using System;
using System.Collections.Generic;
using ToDoApp_Methods;

namespace Methods
{
    public class Class1
    {
        public Tasks AddTask(List<Tasks> TodoList, User currentUser, int listid, string title, string description, DateTime duedate, string prioritylevel, Guid userId)
        {
            Tasks newTask = new Tasks { ListId = listid, Title = title, Description = description, DueDate = duedate, PriorityLevel = prioritylevel, UserId = userId };
            currentUser.TodoList.Add(newTask);
            return newTask;
        }
    }
}
