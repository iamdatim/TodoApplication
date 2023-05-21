using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ToDoApp_Methods;

namespace newToDo
{
    internal class TaskManager
    {
        public static void AddNewItem(List<Tasks> TodoList, User currentUser, List<User> Users)
        {
            Tasks Task = new Tasks();
            int listid = currentUser.TodoList.Count+1;
            Guid userId = currentUser.ID;

            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplayActionMessage("Enter the todo Title: ");
            string title = Console.ReadLine();
            while (Validation.EmptyString(title))
            {
                MenuMessage.DisplayErrorMessage("Todo Title must not be empty.", "Please enter a valid todo Title: ");
                title = Console.ReadLine();
            }

            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplayActionMessage("Enter the todo Description: ");
            string description = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(description))
            {
                MenuMessage.DisplayErrorMessage("Todo Description must not be empty.", "Please enter a valid todo Description: ");
                description = Console.ReadLine();
            }

            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplayActionMessage("Enter the todo Due Date (yyyy/MM/dd): ");

            DateTime duedate;
            string input;
            while (!DateTime.TryParse(input = Console.ReadLine(), out duedate) || duedate < DateTime.Today)
            {
                if (!DateTime.TryParse(input, out duedate))
                {
                    MenuMessage.DisplayErrorMessage("Invalid date format, date must be in this format (yyyy/MM/dd).", "Please enter a valid date: ");
                }
                else if (duedate < DateTime.Today)
                {
                    MenuMessage.DisplayErrorMessage("Date must be a future date.", "Please enter a future date: ");
                }
                else
                {
                    break;
                }
            }

            string[] validInputs = { "High", "Medium", "Low" };
            string prioritylevel = null;
            while (!validInputs.Contains(prioritylevel))
            {
                Header.HeaderDisplay("To do List Application");
                MenuMessage.DisplayActionMessage("Enter the todo Priority Level (High, Medium, Low): ");
                prioritylevel = Console.ReadLine();

                if (!validInputs.Contains(prioritylevel))
                {
                    MenuMessage.DisplayErrorMessage("\n \nInvalid Priority Level.", "Please enter a valid Priority Level: ");
                }
            }
            Tasks newTask = Task.AddTask(TodoList, currentUser, listid, title, description, duedate, prioritylevel, userId);

            WriteToJson writeToJson = new WriteToJson();
            writeToJson.WriteToJsons(Users, TodoList);

            Console.Clear();
            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplaySucessMessage("Item added successfully!");


        }
        public static void ViewToDoList(List<Tasks> TodoList, User currentUser)
        {
            Header.HeaderDisplay("To do List Application");
            if (currentUser.TodoList.Count == 0)
            {
                MenuMessage.DisplayErrorMessage("You do not have any available todo Item.", "");
                return;
            }
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
            Console.WriteLine("\n \n");
        }

        public static void EditExistingItem(List<Tasks> TodoList, User currentUser, List<User> Users)
        {
            Header.HeaderDisplay("To do List Application");
            if (currentUser.TodoList.Count == 0)
            {
                MenuMessage.DisplayErrorMessage("You do not have any available todo Item to edit.","");
                return;
            }

            ViewToDoList(TodoList, currentUser);
            MenuMessage.DisplayActionMessage("\n\nEnter the item number to edit: ");

            int itemId;
            int.TryParse(Console.ReadLine(), out itemId);

            var itemToEdit = currentUser.TodoList.FirstOrDefault(item => item.ListId == itemId);

            if (itemToEdit != null)
            {
                while (true)
                {
                    MenuMessage.DisplayActionMessage("\n\nPlease select an option:\n\n1. Edit Title\n2. Edit Description\n" +
                             "3. Edit Due Date\n4. Edit Priority Level\n5. To Exit\n\nYour Option: ");
                    string editChoice = Console.ReadLine();

                    int value;
                    while (!int.TryParse(editChoice, out value))
                    {
                        MenuMessage.DisplayErrorMessage("Invalid Input, your option should not contain alphabet, character or number.",
                            "Please enter a valid option. eg 1,2,3,4,5: \n\n");
                        MenuMessage.DisplayActionMessage("Please select a valid option:\n\n1. Edit Title\n2. Edit Description\n" +
                            "3. Edit Due Date\n4. Edit Priority Level\n5. To Exit\n\nYour Option: ");
                        editChoice = Console.ReadLine();
                    }

                    switch (editChoice)
                    {
                        case "1":
                            Header.HeaderDisplay("To do List Application");
                            MenuMessage.DisplayActionMessage("Enter the new title: ");
                            string newTitle = Console.ReadLine();
                            itemToEdit.Title = newTitle;
                            while (string.IsNullOrWhiteSpace(newTitle))
                            {
                                MenuMessage.DisplayErrorMessage("Todo Title must not be empty.", "Please enter a valid todo Title: ");
                                newTitle = Console.ReadLine();
                                itemToEdit.Title = newTitle;
                            }
                            WriteToJson editTitle = new WriteToJson();
                            editTitle.WriteToJsons(Users, TodoList);

                            MenuMessage.DisplaySucessMessage("Item Title edited successfully!\n\n");
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "2":
                            Header.HeaderDisplay("To do List Application");
                            MenuMessage.DisplayActionMessage("Enter the new Description: ");

                            string newDescription = Console.ReadLine();
                            itemToEdit.Description = newDescription;
                            while (string.IsNullOrWhiteSpace(newDescription))
                            {
                                MenuMessage.DisplayErrorMessage("Todo Description must not be empty.", "Please enter a valid todo Description: ");
                                newDescription = Console.ReadLine();
                                itemToEdit.Description = newDescription;
                            }

                            WriteToJson editDescription = new WriteToJson();
                            editDescription.WriteToJsons(Users, TodoList);

                            MenuMessage.DisplaySucessMessage("Item Description edited successfully!\n\n");
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "3":
                            Header.HeaderDisplay("To do List Application");

                            MenuMessage.DisplayActionMessage("Enter the new Due Date: ");
                            DateTime newDuedate;
                            string input;
                            while (!DateTime.TryParse(input = Console.ReadLine(), out newDuedate) || newDuedate < DateTime.Today)
                            {
                                if (!DateTime.TryParse(input, out newDuedate))
                                {
                                    MenuMessage.DisplayErrorMessage("Invalid date format, date must be in this format (yyyy/MM/dd).", "Please enter a valid date: ");
                                }
                                else if (newDuedate < DateTime.Today)
                                {
                                    MenuMessage.DisplayErrorMessage("Date must be a future date.", "Please enter a future date: ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            itemToEdit.DueDate = newDuedate;

                            WriteToJson editDueDate = new WriteToJson();
                            editDueDate.WriteToJsons(Users, TodoList);

                            MenuMessage.DisplaySucessMessage("Item Due Date edited successfully!\n\n");
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "4":
                            Header.HeaderDisplay("To do List Application");

                            string[] validInputs = { "High", "Medium", "Low" };
                            itemToEdit.PriorityLevel = null;
                            while (!validInputs.Contains(itemToEdit.PriorityLevel))
                            {
                                MenuMessage.DisplayActionMessage("Enter the new todo Priority Level (High, Medium, Low): ");
                                string newpriority = Console.ReadLine();
                                itemToEdit.PriorityLevel = newpriority;

                                if (!validInputs.Contains(itemToEdit.PriorityLevel))
                                {
                                    MenuMessage.DisplayErrorMessage("\nInvalid Priority Level.", "Please enter a valid Priority Level: ");
                                }
                            }

                            WriteToJson editPriority = new WriteToJson();
                            editPriority.WriteToJsons(Users, TodoList);

                            MenuMessage.DisplaySucessMessage("Item Priority Level edited successfully!\n\n");

                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "5":
                            Header.HeaderDisplay("To do List Application");
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

        public static void MarkAsCompleted(List<Tasks> TodoList, User currentUser, List<User> Users)
        {
            Header.HeaderDisplay("To do List Application");
            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item");
                Console.ResetColor();
                return;
            }

            ViewToDoList(TodoList, currentUser);

            WriteToJson markAsComplete = new WriteToJson();
            markAsComplete.WriteToJsons(Users, TodoList);

            Console.WriteLine();
            Console.Write("Enter the item number to mark as Completed: ");

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
            Header.HeaderDisplay("To do List Application");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task marked as complete successfully!");
            Console.ResetColor();

        }

        public static void DeleteItem(List<Tasks> TodoList, User currentUser, List<User> Users)
        {
            Header.HeaderDisplay("To do List Application");
            if (currentUser.TodoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have any available todo Item to delete.");
                Console.ResetColor();
                return;
            }

            ViewToDoList(TodoList, currentUser);

            WriteToJson deleteTask = new WriteToJson();
            deleteTask.WriteToJsons(Users, TodoList);
            Console.WriteLine();
            MenuMessage.DisplayActionMessage("Enter the item number to delete: ");

            string input = Console.ReadLine();
            int deleteIndex;

            if (int.TryParse(input, out deleteIndex))
            {
                deleteIndex--;

                if (deleteIndex >= 0 && deleteIndex < currentUser.TodoList.Count)
                {
                    currentUser.TodoList.RemoveAt(deleteIndex);

                    Header.HeaderDisplay("To do List Application");
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
