using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace ToDoApp_Methods
{
    public class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Tasks> TodoList { get; set; } = new List<Tasks>();

       

        public User Register(List<User> Users, string fullname, string username, string email, string password)
        {
            User newUser = new User { Fullname = fullname, Username = username, Email = email, Password = password };
            Users.Add(newUser);
            return newUser;
        }
    }
}
