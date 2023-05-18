using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_Methods;

namespace newToDo
{
    internal class MainEntry
    {
        public static void Entry()
        {
            List<User> Users = new List<User>();
            List<Tasks> TodoList = null;

            Header.HeaderDisplay("To Do List Application");
            while (true)
            {
                Console.WriteLine(MenuMessage.MainEntryMenu);

                string choice = Console.ReadLine();
                Console.Clear();

                int value;
                while (Validation.TryParseInt(choice, out value))
                {
                    Header.HeaderDisplay("To do List Application");
                    MenuMessage.DisplayActionMessage("Please select an option:\n \n1. Register\n2. Login\n3. Exit\n ");
                    MenuMessage.DisplayErrorMessage($"{choice} is an Invalid Input, your option should not contain alphabet, character.", "Please enter a valid option. eg 1,2,3: ");
                    choice = Console.ReadLine();
                }
                

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RegistrationPage.Registration(Users);
                        break;

                    case "2":
                        LoginPage loginpage = new LoginPage();
                        loginpage.UserLogin(Users, TodoList);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Header.HeaderDisplay("To do List Application");
                        MenuMessage.DisplayErrorMessage($"{choice} is an Invalid Input, your option should be from 1 to 3.", "\n");
                        break;
                }
            }
        }
    }
}
