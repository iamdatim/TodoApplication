﻿using System;
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
            while (Validation.EmptyString(password))
            {      
                    MenuMessage.DisplayErrorMessage("Password Shouldn't not be empty", "Please enter a valid password:");
                    password = Validation.GetMaskedPassword();
            }

            User newUser = loginManager.Login(Users, username, password);


            ReadFromJson readFromJson = new ReadFromJson();
            List<User> result = readFromJson.ReadFromJsons("Users.json");

            User currentUser = result.FirstOrDefault(x => x.Password == password && x.Username == username);

            //User currentUser = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (currentUser != null)
            {
                Header.HeaderDisplay("To do List Application");
                bool isChoice = true;

                while (isChoice)
                {
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
                            TaskManager.AddNewItem(TodoList, currentUser, Users);
                            break;

                        case "2":
                            Console.Clear();
                            TaskManager.ViewToDoList(TodoList, currentUser);

                            break;

                        case "3":
                            Console.Clear();
                            TaskManager.EditExistingItem(TodoList, currentUser, Users);

                            break;

                        case "4":
                            Console.Clear();
                            TaskManager.MarkAsCompleted(TodoList, currentUser, Users);
                            break;

                        case "5":
                            Console.Clear();
                            TaskManager.DeleteItem(TodoList, currentUser, Users);
                            break;

                        case "6":
                            Console.Clear();
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
                            MenuMessage.DisplayErrorMessage($"{choice} is an Invalid Input, your option should be from 1 to 7.", "\n");
                            break;
                    }
                }
            }

            else
            {
                MenuMessage.DisplayErrorMessage("User Does not exist", "Kindly register an account to be able to login\n\n");
            }


        }

    }
}
