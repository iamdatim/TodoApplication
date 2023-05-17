using System;
using System.Collections.Generic;
using System.Text;

namespace newToDo
{
    internal class MenuMessage
    {
        public static readonly string MainEntryMenu = "Please select an option:\n \n1. Register\n2. Login\n3. Exit\n \nYour Option: ";
        public static readonly string todolistmenu = "Todo List Menu:\n \n1. Add New Item\n2. View Todo List\n3. Edit Existing Item\n4. Mark Item as Completed\n5. Delete Item\n6. View Your Profile\n7. Logout";
        public static readonly string IntErrorMessage = "is an Invalid Input, your option should not contain alphabet, character.";
        public static readonly string ValidOptionMessage = "Please enter a valid option. eg 1,2,3\n";
        public static readonly string EnterOption = "\nYour Option: ";

        public static void DisplayActionMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void DisplayErrorMessage(string message, string retryMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
            Console.WriteLine(retryMessage);
        }

        public static void DisplaySucessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}
