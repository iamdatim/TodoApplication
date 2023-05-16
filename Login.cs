using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoItem
{
    internal class Login
    {
        public static readonly string todolistmenu = "Todo List Menu:\n1. Add New Item\n2. View Todo List\n3. Edit Existing Item\n4. Mark Item as Completed\n5. Delete Item\n6. View Your Profile\n7. Logout";


       
        public static void LoginMethod(List<User> users, List<Tasks> TodoList)
        {
            Header.LoginHeaderDisplay();
            Console.WriteLine("Please enter your Username:");
            string loginUsername = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string loginPassword = Console.ReadLine();
            //string loginPassword = "";
            //ConsoleKeyInfo keyInfo;

            //do
            //{
            //    keyInfo = Console.ReadKey(true);


            //    if (char.IsLetterOrDigit(keyInfo.KeyChar) || keyInfo.Key == ConsoleKey.Backspace)
            //    {

            //        if (keyInfo.Key == ConsoleKey.Backspace && loginPassword.Length > 0)
            //        {
            //            loginPassword = loginPassword.Remove(loginPassword.Length - 1);
            //            Console.Write("\b \b");
            //        }
            //        else
            //        {
            //            loginPassword += keyInfo.KeyChar;
            //            Console.Write("*");
            //        }
            //    }
            //} while (keyInfo.Key != ConsoleKey.Enter);


            Console.WriteLine();

            User currentUser = users.FirstOrDefault(x => x.Username == loginUsername && x.Password == loginPassword);

            if (currentUser != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful!");
                Console.ResetColor();
                bool isChoice = true;
                while (isChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine(todolistmenu);

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

                        Console.WriteLine(todolistmenu);
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

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username or password.");
                Console.ResetColor();
                Console.WriteLine();
            }


        }

        
    }

}
