﻿using System;
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
            // List<BankAccount> UsersBankAccount = new List<BankAccount>();

            Header.HeaderDisplay("To Do List Application");
            while (true)
            {
                // Header.HeaderDisplay("Datim Bank Plc");
                Console.WriteLine(MenuMessage.MainEntryMenu);

                string choice = Console.ReadLine();
                Console.Clear();

                int value;
                while (Validation.TryParseInt(choice, out value))
                {
                    Header.HeaderDisplay("To do List Application");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{choice} {MenuMessage.IntErrorMessage}");
                    Console.ResetColor();
                    Console.WriteLine($"{MenuMessage.ValidOptionMessage}");
                    Console.WriteLine(MenuMessage.MainEntryMenu);
                    //Console.WriteLine(MenuMessage.EnterOption);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{choice} {MenuMessage.IntErrorMessage}");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}