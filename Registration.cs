using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToDoItem
{
    internal class Registration
    {


        public static void Register(List<User> users, List<Tasks> TodoList) 
        {
            // List<User> users = new List<User>();

            User user = new User();

            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            Regex regexUsername = new Regex("^[a-zA-Z]+$");
           // Regex regexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,}$");
            Regex regexps = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
           // Regex regexChoice = new Regex(@"^\d+$");


            //User newUser = new User();

            Header.RegisterHeaderDisplay();
            Console.Write("Please enter a Full Name: ");
            user.Fullname = Console.ReadLine();
            //string input = Console.ReadLine();
            //string[] inputs = user.Fullname.Split(' ');
            string[] inputValues = user.Fullname.Split(' ');


            while (string.IsNullOrWhiteSpace(user.Fullname) || !regexUsername.IsMatch(user.Fullname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Full Name format, Name must \nnot contain number or character.");
                Console.ResetColor();
                Console.Write("Please enter a valid Full Name: ");
                user.Fullname = Console.ReadLine();
            }

            //while (inputValues.Length != 2)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("name must be more than 1");
            //    Console.ResetColor();
            //    Console.Write("Please enter a valid Full Name: ");
            //    user.Fullname = Console.ReadLine();
            //}

            Console.Write("Please enter a username: ");
            user.Username = Console.ReadLine();

            while (!regexUsername.IsMatch(user.Username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username format, username must \nnot contain number or character.");
                Console.ResetColor();
                Console.Write("Please enter a valid username: ");
                user.Username = Console.ReadLine();
            }

           // User UserExist = users.FirstOrDefault(x => x.Username == user.Username);

            while (users.Exists(x => x.Username == user.Username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exist");
                Console.ResetColor();
                Console.Write("Please enter another username: ");
                user.Username = Console.ReadLine();
            }


            Console.Write("Please enter an email address: ");
            user.Email = Console.ReadLine();

            while (!regex.IsMatch(user.Email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email address. Please enter a valid email address.");
                Console.ResetColor();
                Console.Write("Enter an email address: ");
                user.Email = Console.ReadLine();
            }

            while (users.Exists(x => x.Email == user.Email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email already exist");
                Console.ResetColor();
                Console.Write("Please enter another Email: ");
                user.Email = Console.ReadLine();
            }


            Console.Write("Please enter a password: ");
            user.Password = Console.ReadLine();
            //user.Password = "";
            ////string password = "";
            //ConsoleKeyInfo keyInfo;

            //do
            //{
            //    keyInfo = Console.ReadKey(true);


            //    if (char.IsLetterOrDigit(keyInfo.KeyChar) || keyInfo.Key == ConsoleKey.Backspace)
            //    {

            //        if (keyInfo.Key == ConsoleKey.Backspace && user.Password.Length > 0)
            //        {
            //            user.Password = user.Password.Remove(user.Password.Length - 1);
            //            Console.Write("\b \b");
            //        }
            //        else
            //        {
            //            user.Password += keyInfo.KeyChar;
            //            Console.Write("*");
            //        }
            //    }
            //} while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
           
            while (!regexps.IsMatch(user.Password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password Requiremnet not met, Your Password must contain \nat least 1 Uppercase, Lowercase and Number ");
                Console.ResetColor();
                Console.Write("Enter a strong Password: ");
                user.Password = "";
                ConsoleKeyInfo keyInfoo;

                do
                {
                    keyInfoo = Console.ReadKey(true);


                    if (char.IsLetterOrDigit(keyInfoo.KeyChar) || keyInfoo.Key == ConsoleKey.Backspace)
                    {

                        if (keyInfoo.Key == ConsoleKey.Backspace && user.Password.Length > 0)
                        {
                            user.Password = user.Password.Remove(user.Password.Length - 1);
                            Console.Write("\b \b");
                        }
                        else
                        {
                            user.Password += keyInfoo.KeyChar;
                            Console.Write("*");
                        }
                    }
                } while (keyInfoo.Key != ConsoleKey.Enter);
                Console.WriteLine();
            }

           
            //user.Password = ConfirmPassword;
            Console.Write("Please confirm your password: ");
            string ConfirmPassword = Console.ReadLine();
            //string ConfirmPassword = "";
            // ConsoleKeyInfo keyInfooo;

            // do
            // {
            //     keyInfooo = Console.ReadKey(true);


            //     if (char.IsLetterOrDigit(keyInfooo.KeyChar) || keyInfooo.Key == ConsoleKey.Backspace)
            //     {

            //         if (keyInfooo.Key == ConsoleKey.Backspace && user.ConfirmPassword.Length > 0)
            //         {
            //             user.ConfirmPassword = user.ConfirmPassword.Remove(user.ConfirmPassword.Length - 1);
            //             Console.Write("\b \b");
            //         }
            //         else
            //         {
            //             user.ConfirmPassword += keyInfooo.KeyChar;
            //             Console.Write("*");
            //         }
            //     }
            // } while (keyInfooo.Key != ConsoleKey.Enter);

            Console.WriteLine();

            //while (!regexps.IsMatch(user.Password))
            //{
            while (ConfirmPassword != user.Password)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password does not match");
                Console.ResetColor();
                Console.Write("Please confirm your Password: ");

                ConfirmPassword = "";
                // string password = "";
                ConsoleKeyInfo keyInfoo;

                do
                {
                    keyInfoo = Console.ReadKey(true);


                    if (char.IsLetterOrDigit(keyInfoo.KeyChar) || keyInfoo.Key == ConsoleKey.Backspace)
                    {

                        if (keyInfoo.Key == ConsoleKey.Backspace && ConfirmPassword.Length > 0)
                        {
                            ConfirmPassword = ConfirmPassword.Remove(ConfirmPassword.Length - 1);
                            Console.Write("\b \b");
                        }
                        else
                        {
                            ConfirmPassword += keyInfoo.KeyChar;
                            Console.Write("*");
                        }
                    }
                } while (keyInfoo.Key != ConsoleKey.Enter);
                Console.WriteLine();
            }

            //User newUser = new User { Fullname = user.Fullname, Username = user.Username, Email = email, Password = password, ID = Guid.NewGuid() };
            users.Add(user);

            Console.Clear();
            Animation.RegistrationLoading();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User registered successfully!");
            Console.ResetColor();
            Console.WriteLine();

            Animation.LoginLoading();
            Header.HeaderDisplay();

            RedirectLogin(users, TodoList, user);
        }


        public static void RedirectLogin(List<User> users, List<Tasks> TodoList, User user)
        {
            User currentUser = users.FirstOrDefault(x => x.Username == user.Fullname && x.Password == user.Password);
            bool isChoice = true;
            while (isChoice)
            {
                Console.WriteLine();
                Console.WriteLine(Login.todolistmenu);

                Console.WriteLine();
                Console.Write("Enter your choice: ");
                string todoChoice = Console.ReadLine();
                Console.Clear();

                int value;

                while (!int.TryParse(todoChoice, out value))
                {
                    Header.HeaderDisplay();
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine($"{choice} {value}";
                    Console.WriteLine($"{todoChoice} is an Invalid Input, your option should not contain alphabet, character.");
                    Console.ResetColor();
                    Console.WriteLine("Please enter a valid option. eg 1,2,3,4,5: ");
                    Console.WriteLine();

                    Console.WriteLine(Login.todolistmenu);
                    Console.WriteLine();
                    Console.Write("Your Option: ");
                    todoChoice = Console.ReadLine();
                }
                switch (todoChoice)
                {

                    case "1":
                        Console.Clear();
                        TaskManagement.AddNewItem(TodoList, currentUser);
                        break;

                    case "2":
                        Console.Clear();
                        TaskManagement.ViewToDoList(TodoList, currentUser);

                        break;

                    case "3":
                        Console.Clear();
                        TaskManagement.EditExistingItem(TodoList, currentUser);

                        break;

                    case "4":
                        Console.Clear();
                        TaskManagement.MarkAsCompleted(TodoList, currentUser);
                        break;

                    case "5":
                        Console.Clear();
                        TaskManagement.DeleteItem(TodoList, currentUser);
                        break;

                    case "6":
                        Console.Clear();
                        //ViewYourProfile(registeredUsers);
                        Header.ProfileHeaderDisplay();
                        Console.WriteLine($"Name: \t\t {currentUser.Fullname}");
                        Console.WriteLine($"Username: \t {currentUser.Username}");
                        Console.WriteLine($"Email Address: \t {currentUser.Email}");
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine(new string(Header.headerLine, Header.headerLineWidth));
                        Console.ResetColor();
                        Console.WriteLine();
                        break;

                    case "7":
                        Console.Clear();
                        isChoice = false;
                        Console.WriteLine();
                        Console.WriteLine("You've Logged out successfully.");
                        Console.WriteLine();
                        break;

                    default:
                        Header.HeaderDisplay();
                        Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine($"{choice} {value}";
                        Console.WriteLine($"{todoChoice} is an Invalid Input, your option should not contain alphabet, character.");
                        Console.ResetColor();
                        break;
                }

            }
        }
    }


}
