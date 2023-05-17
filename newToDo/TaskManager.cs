using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp_Methods;

namespace newToDo
{
    internal class TaskManager
    {
        public static void AddNewItem(List<Tasks> TodoList, User currentUser)
        {
            Tasks Task = new Tasks();
            int listid = currentUser.TodoList.Count+1;
            Task.UserId = currentUser.ID;

            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplayActionMessage("Enter the todo Title: ");
            string title = Console.ReadLine();
            while (Validation.EmptyString(title))
            {
                MenuMessage.DisplayErrorMessage("\n \nTodo Title must not be empty.", "Please enter a valid todo Title: ");
                title = Console.ReadLine();
            }

            MenuMessage.DisplayActionMessage("Enter the todo Description: ");
            string description = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(description))
            {
                MenuMessage.DisplayErrorMessage("\n \nTodo Description must not be empty.", "Please enter a valid todo Description: ");
                description = Console.ReadLine();
            }

            MenuMessage.DisplayActionMessage("Enter the todo Due Date (yyyy/MM/dd): ");
            DateTime duedate = DateTime.Parse(Console.ReadLine());
            DateTime date = DateTime.Now;
            while (!DateTime.TryParse(duedate.ToShortDateString(), out date) || date < DateTime.Now)
            {
                MenuMessage.DisplayErrorMessage("\n \nInvalid date format, date must be in this format\n(yyyy/MM/dd) and must be a future date.", "Please enter a valid date: ");
                duedate = DateTime.Parse(Console.ReadLine());
            }

            string[] validInputs = { "High", "Medium", "Low" };
            string prioritylevel = null;
            while (!validInputs.Contains(prioritylevel))
            {
                MenuMessage.DisplayActionMessage("Enter the todo Priority Level (High, Medium, Low): ");
                //Task.PriorityLevel = Console.ReadLine();
                prioritylevel = Console.ReadLine();

                if (!validInputs.Contains(prioritylevel))
                {
                    MenuMessage.DisplayErrorMessage("\n \nInvalid Priority Level.", "Please enter a valid Priority Level: ");
                }
            }
            //currentUser.TodoList.Add(Task);
            Tasks newTask = Task.AddTask(TodoList, currentUser, listid, title, description, duedate, prioritylevel);

            Console.Clear();
            Header.HeaderDisplay("To do List Application");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item added successfully!");
            Console.ResetColor();


        }
        public static void ViewToDoList(List<Tasks> TodoList, User currentUser)
        {
            Header.HeaderDisplay("To do List Application");
            if (currentUser.TodoList.Count == 0)
            {
                MenuMessage.DisplayErrorMessage("You do not have any available todo Item.", "");
                return;
            }

            //Header.HeaderDisplay("To do List Application");
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

        public static void EditExistingItem(List<Tasks> TodoList, User currentUser)
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
                            //Console.Write("Enter the new title: ");
                            MenuMessage.DisplayActionMessage("Enter the new title: ");
                            string newTitle = Console.ReadLine();
                            itemToEdit.Title = newTitle;
                            while (string.IsNullOrWhiteSpace(newTitle))
                            {
                                MenuMessage.DisplayErrorMessage("\n \nTodo Title must not be empty.", "Please enter a valid todo Title: ");
                                newTitle = Console.ReadLine();
                                itemToEdit.Title = newTitle;
                            }
                            MenuMessage.DisplaySucessMessage("Item Title edited successfully!\n\n");
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "2":
                            Header.HeaderDisplay("To do List Application");

                            //Console.Write("Enter the new Description: ");
                            MenuMessage.DisplayActionMessage("Enter the new Description: ");

                            string newDescription = Console.ReadLine();
                            itemToEdit.Description = newDescription;
                            while (string.IsNullOrWhiteSpace(newDescription))
                            {
                                MenuMessage.DisplayErrorMessage("\n \nTodo Description must not be empty.", "Please enter a valid todo Description: ");
                                newDescription = Console.ReadLine();
                                itemToEdit.Description = newDescription;
                            }
                            MenuMessage.DisplaySucessMessage("Item Description edited successfully!\n\n");
                            ViewToDoList(TodoList, currentUser);
                            Console.WriteLine();
                            break;

                        case "3":
                            Header.HeaderDisplay("To do List Application");

                            //Console.Write("Enter the new Due Date: ");
                            MenuMessage.DisplayActionMessage("Enter the new Due Date: ");
                            DateTime newDuedate = DateTime.Parse(Console.ReadLine());
                            itemToEdit.DueDate = newDuedate;
                            DateTime date = DateTime.Now;
                            while (!DateTime.TryParse(newDuedate.ToShortDateString(), out date) || date < DateTime.Now)
                            {
                                MenuMessage.DisplayErrorMessage("\n \nInvalid date format, date must be in this format\n(yyyy/MM/dd) and must be a future date.", "Please enter a valid date: ");
                                newDuedate = DateTime.Parse(Console.ReadLine());
                                itemToEdit.DueDate = newDuedate;
                            }

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

        public static void MarkAsCompleted(List<Tasks> TodoList, User currentUser)
        {
            //Header.HeaderDisplay();
            Header.HeaderDisplay("To do List Application");
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
            Header.HeaderDisplay("To do List Application");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task marked as complete successfully!");
            Console.ResetColor();

        }

        public static void DeleteItem(List<Tasks> TodoList, User currentUser)
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
            Console.WriteLine();
            MenuMessage.DisplayActionMessage("Enter the item number to delete: ");
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
