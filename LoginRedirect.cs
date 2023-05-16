using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoItem
{
    internal class LoginRedirect
    {
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
                    
                    Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.WriteLine(new string(Header.headerLine, Header.headerLineWidth));
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
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

            }
        }
    }
}
