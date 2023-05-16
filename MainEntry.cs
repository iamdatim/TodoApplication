using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ToDoItem
{
    internal class MainEntry
    {
        public static void Entry(List<Tasks> TodoList, List<User> users)
        {
            Header.HeaderDisplay();
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.WriteLine();
                Console.Write("Your Option: ");
                
                string choice = (Console.ReadLine());
                Console.Clear();


                int value;

                while (!int.TryParse(choice, out value))
                {
                    Header.HeaderDisplay();
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine($"{choice} {value}";
                    Console.WriteLine($"{choice} is an Invalid Input, your option should not contain alphabet, character.");
                    Console.ResetColor();
                    Console.WriteLine("Please enter a valid option. eg 1,2,3: ");
                    Console.WriteLine();

                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");

                    Console.WriteLine();
                    Console.Write("Your Option: ");
                    choice = Console.ReadLine();
                }

                Console.Clear();
        
                switch (choice)
                {
                    case "1":
                        Registration.Register(users, TodoList);
                        break;

                    case "2":
                        Login.LoginMethod(users, TodoList);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        }
}
