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
            // return int.TryParse(input, out result);
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
            // return int.TryParse(input, out result);
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        public static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for email validation
            string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Use Regex.IsMatch to test the email against the pattern
            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool IsValidPassword(string password)
        {
            // Define a regular expression pattern for email validation
            string PasswordPattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";

            // Use Regex.IsMatch to test the email against the pattern
            return Regex.IsMatch(password, PasswordPattern);
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

                // Break the loop when Enter key is pressed
                if (keyPressed == '\r')
                    break;

                // Handle backspace
                if (keyPressed == '\b')
                {
                    if (password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b"); // Clear the character on the console
                    }
                }
                else
                {
                    password += keyPressed;
                    Console.Write("*"); // Display asterisk symbol instead of the actual character
                }
            }

            Console.WriteLine(); // Move to the next line after password entry
            return password;
        }

    }
}
