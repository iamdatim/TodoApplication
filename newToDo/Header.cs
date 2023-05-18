using System;
using System.Collections.Generic;
using System.Text;

namespace newToDo
{
    internal class Header
    {
        public static char headerLine = '-';
        public static int headerLineWidth = 118;

        public static void HeaderDisplay(string message)
        {
            Console.Clear();
            Animation.ProcessLoading();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine(CentreText(message, headerLineWidth));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }
    }
}
