using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToDoApp_Methods
{
    public class Validation
    {
        public static bool TryParseInt(string input, out int result)
        {
            
            if (!int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EmptyString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static bool IsValidEmail(string email)
        {
            string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool IsValidPassword(string password)
        {
            string PasswordPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";

            return Regex.IsMatch(password, PasswordPattern);
        }

        public static bool IsSpecialCharacter(string fullname)
        {
            string fullnamePattern = @"^[a-zA-Z0-9\s]+$";

            return Regex.IsMatch(fullname, fullnamePattern);
        }

        public static bool UserExists(List<User> Users, User user)
        {
            return Users.Any(u => u.Username == user.Username || u.Email == user.Email);
        }

        public static bool UserNameExist(List<User> Users, User user)
        {
            if (Users.Exists(x => x.Username == user.Username))
            {
                return true;
            }

            else
            {
                return false;
            }
        }



        public static string GetMaskedPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char keyPressed = keyInfo.KeyChar;

                if (keyPressed == '\r')
                    break;

                if (keyPressed == '\b')
                {
                    if (password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b"); 
                    }
                }
                else
                {
                    password += keyPressed;
                    Console.Write("*"); 
                }
            }

            Console.WriteLine();
            return password;
        }

        public bool IsValidDateTime(string input, out DateTime dateTime)
        {
            if (!DateTime.TryParse(input, out dateTime))
            {
             //   Console.WriteLine("Invalid date and time format. Please try again.");
                return false;
            }

            return true;
        }

    }
}
