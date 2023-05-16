using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem
{
    internal class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Tasks> TodoList { get; set; } = new List<Tasks>();
    }
}
