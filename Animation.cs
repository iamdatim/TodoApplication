using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ToDoItem
{
    public class Animation
    {
        public static void EntryLoading()
        {
            Console.Write("Loading");


            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }


        }

        public static void ProcessLoading()
        {
            Console.Write("Loading ");


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.Write("~");
            }


        }

        public static void LoginLoading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Logging You In ");
            Console.ResetColor();


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("~");
                Console.ResetColor();
            }


        }

        public static void RegistrationLoading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Registering Your Account");
            Console.ResetColor();


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("~");
                Console.ResetColor();
            }


        }
    }
}
