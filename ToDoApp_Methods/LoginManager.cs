using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp_Methods
{
    public class LoginManager
    {
        public User Login(List<User> Users, string username, string password)
        {
            foreach (User user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }

                else
                {
                    return null;
                }
            }

            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
