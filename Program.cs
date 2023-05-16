using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToDoItem
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            
            List<Tasks> TodoList = new List<Tasks>();


            MainEntry.Entry(TodoList, users);
        }

    }
}
