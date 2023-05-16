using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToDoItem
{
    internal class TaskManagement
    {

        public static void AddNewItem(List<Tasks> TodoList, User currentUser)
        {
            Tasks Task = new Tasks();

            Task.ListId = currentUser.TodoList.Count + 1;

            Task.UserId = currentUser.ID;

            Header.HeaderDisplay();
            Console.Write("Enter the todo Title: ");
            Task.Title = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(Task.Title))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid todo Title format, todo Title must \nnot be empty.");
                Console.ResetColor();
                Console.Write("Please enter a valid todo Title: ");
                Task.Title = Console.ReadLine();
            }

            Console.Write("Enter the todo Description: ");
            Task.Description = Console.ReadLine();



            while (string.IsNullOrWhiteSpace(Task.Description))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid todo Description format, todo Title must \nnot be empty.");
                Console.ResetColor();
                Console.Write("Please enter a valid todo Description: ");
                Task.Description = Console.ReadLine();
            }

            Console.Write("Enter the todo Due Date (yyyy/MM/dd): ");
            Task.DueDate = DateTime.Parse(Console.ReadLine());

            //DateTime date;
            DateTime date = DateTime.Now;
            while (!DateTime.TryParse(Task.DueDate.ToShortDateString(), out date) || date < DateTime.Now)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format, date must be in this format\n(yyyy/MM/dd) and must be a future date.");
                Console.ResetColor();
                Console.Write("Please enter a valid date: ");
                Task.DueDate = DateTime.Parse(Console.ReadLine());
            }

            string[] validInputs = { "High", "Medium", "Low" };
            Task.PriorityLevel = null;
            while (!validInputs.Contains(Task.PriorityLevel))
            {
                Console.Write("Enter the todo Priority Level (High, Medium, Low): ");
                Task.PriorityLevel = Console.ReadLine();

                if (!validInputs.Contains(Task.PriorityLevel))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Priority Level. Please enter a Valid Priority Level.");
                    Console.ResetColor();
                }
            }
            currentUser.TodoList.Add(Task);

            Console.Clear();
            Header.HeaderDisplay();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item added successfully!");
            Console.ResetColor();


        }
        public static void ViewToDoList(List<Tasks> TodoList, User currentUser)
        {

            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item");
                Console.ResetColor();
                return;
            }

            Console.Clear();
            Header.HeaderDisplay();
            Console.WriteLine(TableUI.CentreText("Avalable Todo Task", TableUI.tableWidth));
            TableUI.PrintLine();
            Console.ForegroundColor = ConsoleColor.Green;
            TableUI.PrintRow("ID", "Title", "Description", "Due Date", "Priority Level", "Complete");
            Console.ResetColor();
            TableUI.PrintLine();
            foreach (Tasks item in currentUser.TodoList)
            {

                TableUI.PrintRow(item.ListId.ToString(), item.Title,
                    item.Description, item.DueDate.ToString("yyyy/MM/dd"), item.PriorityLevel,
                    item.IsComplete ? "Yes" : "No");

                TableUI.PrintLine();

            }
            //TableUI.PrintLine();
            Console.WriteLine("\n \n");
        }

        public static void EditExistingItem(List<Tasks> TodoList, User currentUser)
        {

            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item to edit.");
                Console.ResetColor();
                return;
            }

            ViewToDoList(TodoList, currentUser);
            Console.WriteLine();
            Console.Write("Enter the item number to edit: ");

            //int itemId = int.TryParse(Console.ReadLine());

            int itemId;
            int.TryParse(Console.ReadLine(), out itemId);
          

            var itemToEdit = currentUser.TodoList.FirstOrDefault(item => item.ListId == itemId);

            //var itemToEdit = currentUser.TodoList.FirstOrDefault(item => item.ListId == itemId);


            if (itemToEdit != null)
            {

                Console.WriteLine();


                while (true)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine();
                    Console.WriteLine("1. Edit Title");
                    Console.WriteLine("2. Edit Description");
                    Console.WriteLine("3. Edit Due Date");
                    Console.WriteLine("4. Edit Priority Level");
                    Console.WriteLine("5. To Exit");

                    Console.WriteLine();
                    Console.Write("Your Option: ");
                    string editChoice = Console.ReadLine();

                    int value;

                    while (!int.TryParse(editChoice, out value))
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Input, your option should not contain alphabet, character or number.");
                        Console.ResetColor();
                        Console.WriteLine("Please enter a valid option. eg 1,2,3,4,5: ");
                        Console.WriteLine();

                        Console.WriteLine("Please select a valid option:");
                        Console.WriteLine();
                        Console.WriteLine("1. Edit Title");
                        Console.WriteLine("2. Edit Description");
                        Console.WriteLine("3. Edit Due Date");
                        Console.WriteLine("4. Edit Priority Level");
                        Console.WriteLine("5. To Exit");

                        Console.WriteLine();
                        Console.Write("Your Option: ");
                        editChoice = Console.ReadLine();


                    }

                    switch (editChoice)
                    {
                        case "1":
                            Header.HeaderDisplay();

                            Console.Write("Enter the new title: ");
                            string newTitle = Console.ReadLine();
                            itemToEdit.Title = newTitle;
                            while (string.IsNullOrWhiteSpace(newTitle))
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid todo Title format, todo Title must \nnot be empty.");
                                Console.ResetColor();
                                Console.Write("Please enter a valid todo Title: ");
                                newTitle = Console.ReadLine();
                                itemToEdit.Title = newTitle;
                            }
                            //Animation.ProcessLoading();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Item Title edited successfully!");
                            Console.ResetColor();
                            Console.WriteLine();
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "2":
                            Header.HeaderDisplay();

                            Console.Write("Enter the new Description: ");

                            string newDescription = Console.ReadLine();
                            itemToEdit.Description = newDescription;
                            while (string.IsNullOrWhiteSpace(newDescription))
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid todo Title format, todo Title must \nnot be empty.");
                                Console.ResetColor();
                                Console.Write("Please enter a valid todo Title: ");
                                newDescription = Console.ReadLine();
                                itemToEdit.Description = newDescription;
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Item Description edited successfully!");
                            Console.ResetColor();
                            Console.WriteLine();
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "3":
                            Header.HeaderDisplay();

                            Console.Write("Enter the new Due Date: ");
                            DateTime newDuedate = DateTime.Parse(Console.ReadLine());
                            itemToEdit.DueDate = newDuedate;
                            DateTime date = DateTime.Now;
                            while (!DateTime.TryParse(newDuedate.ToShortDateString(), out date) || date < DateTime.Now)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid date format, date must be in this format\n(yyyy/MM/dd) and must be a future date.");
                                Console.ResetColor();
                                Console.Write("Please enter a valid date: ");
                                newDuedate = DateTime.Parse(Console.ReadLine());
                                itemToEdit.DueDate = newDuedate;
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Item Due Date edited successfully!");
                            Console.ResetColor();
                            Console.WriteLine();
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "4":
                            Header.HeaderDisplay();

                            string[] validInputs = { "High", "Medium", "Low" };
                            itemToEdit.PriorityLevel = null;
                            while (!validInputs.Contains(itemToEdit.PriorityLevel))
                            {
                                Console.Write("Enter the new todo Priority Level (High, Medium, Low): ");
                                string newpriority = Console.ReadLine();
                                itemToEdit.PriorityLevel = newpriority;

                                if (!validInputs.Contains(itemToEdit.PriorityLevel))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Priority Level. Please enter a Valid Priority Level.");
                                    Console.ResetColor();
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Item Priority Level edited successfully!");
                            Console.ResetColor();
                            Console.WriteLine();

                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "5":
                            Header.HeaderDisplay();
                            return;


                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }


                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found.");
                Console.ResetColor();

            }
        }

        public static void MarkAsCompleted(List<Tasks> TodoList, User currentUser)
        {
            //Header.HeaderDisplay();

            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item");
                Console.ResetColor();
                return;
            }

            ViewToDoList(TodoList, currentUser);
            Console.WriteLine();
            Console.Write("Enter the item number to mark as Completed: ");
            // int itemId = int.Parse(Console.ReadLine());
            //string number = Console.ReadLine();

            int itemId;

            while (!int.TryParse(Console.ReadLine(), out itemId) || itemId < 1 || itemId > currentUser.TodoList.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found, Please enter a correct Item Number.");
                Console.ResetColor();
                return;
            }


            Tasks item = currentUser.TodoList[itemId - 1];
            item.IsComplete = true;

            Console.Clear();
            Header.HeaderDisplay();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task marked as complete successfully!");
            Console.ResetColor();

        }

        public static void DeleteItem(List<Tasks> TodoList, User currentUser)
        {

            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item to delete.");
                Console.ResetColor();
                return;
            }

            ViewToDoList(TodoList, currentUser);
            Console.WriteLine();
            Console.Write("Enter the item number to delete: ");
            // int deleteIndex = int.Parse(Console.ReadLine()) - 1;

            //int deleteIndex;
            //while (int.TryParse(Console.ReadLine(), out deleteIndex))
            //{
            //    deleteIndex =- 1;
            //    // Use the updated value of deleteIndex
            //}

            //if (deleteIndex >= 0 && deleteIndex < currentUser.TodoList.Count)
            //{
            //    currentUser.TodoList.RemoveAt(deleteIndex);


            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Item deleted successfully!");
            //    Console.ResetColor();

            //}
            //else
            //{

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Invalid item number.");
            //    Console.ResetColor();
            //}

            string input = Console.ReadLine();
            int deleteIndex;

            if (int.TryParse(input, out deleteIndex))
            {
                // Adjust the index to match the list index (subtracting 1)
                deleteIndex--;

                if (deleteIndex >= 0 && deleteIndex < currentUser.TodoList.Count)
                {
                    currentUser.TodoList.RemoveAt(deleteIndex);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Item deleted successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid item number.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid item number.");
                Console.ResetColor();
            }




        }
    }
}
