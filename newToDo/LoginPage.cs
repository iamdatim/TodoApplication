using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp_Methods;

namespace newToDo
{
    internal class LoginPage
    {
        private LoginManager loginManager = new LoginManager();
        public void UserLogin(List<User> Users, List<Tasks> TodoList)
        {
            Header.HeaderDisplay("Login Page");

            MenuMessage.DisplayActionMessage("Please enter your username: ");
            string username = Console.ReadLine();
            int value;
            while (Validation.EmptyString(username) || !Validation.TryParseInt(username, out value))
            {
                if (Validation.EmptyString(username))
                {
                    Header.HeaderDisplay("To do List Application");
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not be empty", "Please enter a valid username:");
                    username = Console.ReadLine();
                }

                else if (!Validation.TryParseInt(username, out value))
                {
                    Header.HeaderDisplay("To do List Application");
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not contain number", "Please enter a valid username:");
                    username = Console.ReadLine();
                }
            }
            Console.Clear();

            Header.HeaderDisplay("Login Page");
            MenuMessage.DisplayActionMessage("Please enter your Password: ");
            string password = Validation.GetMaskedPassword();
            while (Validation.EmptyString(password) || !Validation.IsValidPassword(password))
            {
                if (Validation.EmptyString(password))
                {
                    MenuMessage.DisplayErrorMessage("Password Shouldn't not be empty", "Please enter a valid password:");
                    password = Validation.GetMaskedPassword();
                }

                else if (!Validation.IsValidEmail(password))
                {
                    MenuMessage.DisplayErrorMessage("Password Requiremnet not met, Your Password must contain \nat least 1 Uppercase, Lowercase and Number", "Please enter a valid password:");
                    password = Validation.GetMaskedPassword();
                }
            }

            User newUser = loginManager.Login(Users, username, password);

   
            User currentUser = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (currentUser != null)
            {
                Header.HeaderDisplay("To do List Application");
                //MenuMessage.DisplaySucessMessage("Login Sucessful");
                bool isChoice = true;

                while (isChoice)
                {
                    // Header.HeaderDisplay("Datim Bank Plc");
                    Console.WriteLine(MenuMessage.todolistmenu);
                    MenuMessage.DisplayActionMessage("\n\nYour Option: ");
                    string choice = Console.ReadLine();
                    Console.Clear();

                    int type;
                    while (Validation.TryParseInt(choice, out type))
                    {
                        Header.HeaderDisplay("To do List Application");
                        MenuMessage.DisplayActionMessage("\n\nTodo List Menu:\n \n1. Add New Item\n2. View Todo List\n3. Edit Existing Item\n4. Mark Item as Completed\n5. Delete Item\n6. View Your Profile\n7. Logout\n\n ");
                        MenuMessage.DisplayErrorMessage($"{choice} is an Invalid Input, your option should not contain alphabet, character.", "Please enter a valid option. eg 1,2,3: ");
                        choice = Console.ReadLine();
                    }

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            TaskManager.AddNewItem(TodoList, currentUser);
                            break;

                        case "2":
                            Console.Clear();
                            TaskManager.ViewToDoList(TodoList, currentUser);

                            break;

                        case "3":
                            Console.Clear();
                            TaskManager.EditExistingItem(TodoList, currentUser);

                            break;

                        case "4":
                            Console.Clear();
                            TaskManager.MarkAsCompleted(TodoList, currentUser);
                            break;

                        case "5":
                            Console.Clear();
                            TaskManager.DeleteItem(TodoList, currentUser);
                            break;

                        case "6":
                            Console.Clear();
                            //ViewYourProfile(registeredUsers);
                            Header.HeaderDisplay("Your Profile");
                            Console.WriteLine($"Name: \t\t {currentUser.Fullname}");
                            Console.WriteLine($"Username: \t {currentUser.Username}");
                            Console.WriteLine($"Email Address: \t {currentUser.Email}");
                            Console.WriteLine(new string(Header.headerLine, Header.headerLineWidth));
                            Console.WriteLine();
                            break;

                        case "7":
                            Console.Clear();
                            isChoice = false;
                            Header.HeaderDisplay("To do List Application");
                            Console.WriteLine("You've Logged out successfully.");
                            Console.WriteLine();
                            break;

                        default:
                            Header.HeaderDisplay("To do List Application");
                            MenuMessage.DisplayErrorMessage($"{choice} is an Invalid Input, your option should not contain alphabet, character.", "Please enter a valid option.\n");
                            break;

                        //default:
                        //    Header.HeaderDisplay("To do List Application");
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.WriteLine($"{choice} {MenuMessage.IntErrorMessage}");
                        //    Console.ResetColor();
                        //    break;
                    }
                }
            }

            else
            {
                MenuMessage.DisplayErrorMessage("User Does not exist", "Kindly register an account to be able to login");
            }


        }

    }
}
