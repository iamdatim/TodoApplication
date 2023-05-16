using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem
{
    internal class Header
    {
        public static char headerLine = '-';
        public static int headerLineWidth = 120;

        public static void HeaderDisplay()
        {


            Console.Clear();
            Animation.ProcessLoading();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------- To Do List Application -------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ProfileHeaderDisplay()
        {
            Console.Clear();
            Animation.ProcessLoading();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------- Your Profile ------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void LoginHeaderDisplay()
        {
            Console.Clear();
            Animation.ProcessLoading();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------- Login Page -------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void RegisterHeaderDisplay()
        {
            Console.Clear();
            Animation.ProcessLoading();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------- Registration Page ---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(headerLine, headerLineWidth));
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public class TableUI
    {
        public static readonly int tableWidth = 118;
        //public static void DisplayCalHeader()
        //{
        //    // Define the header text
        //    string headerText = "CGPA Calculator";

        //    // Calculate the center position of the header based on the console width
        //    int headerWidth = headerText.Length + 4;
        //    int centerPosition = (Console.WindowWidth / 2) - (headerWidth / 2);

        //    // Display the centered header
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(new string('=', 120));
        //    Console.WriteLine($"{new string(' ', centerPosition)}|  {headerText}  |");
        //    Console.WriteLine(new string('=', 120));
        //    Console.ResetColor();
        //}


        //public static void PrintTable(List<Tasks> TodoList)
        //{

        //    Console.Clear();
        //    Console.WriteLine(CentreText("CGPA Calculator", tableWidth));
        //    PrintLine();
        //    PrintRow("ID", "Title", "Description", "Due Date", "Priority Level", "Complete");
        //    PrintLine();
        //    foreach (Tasks item in TodoList)
        //    {
        //        PrintRow(item.ListId, item.Title,
        //            item.Description, item.DueDate.ToString(), item.PriorityLevel,
        //            item.IsComplete ? "Yes" : "No");


        //        //totalCourseUnit += course.CourseUnit;
        //        //totalUnitPass += course.IsPassed == true ? course.CourseUnit : 0;
        //        //totalWeightPoint += course.WeightPoint;
        //    }
        //    PrintLine();
        //    Console.WriteLine("\n \n");

        //    //double totalCourseUnit = courses.Sum(x => x.CourseUnit);
        //    //double totalUnitPass = courses.Where(x => x.IsPassed == true).Select(y => y.CourseUnit).Sum();
        //    //double totalWeightPoint = courses.Sum(x => x.WeightPoint);

        //}

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
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
