using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoApp_Methods;

namespace newToDo
{
    internal class WriteToJson
    {
        //public void WriteToJsons(List<User> Users)
        //{
        //    string fileName = "Users.json";
        //    string currentDir = Environment.CurrentDirectory;
        //    DirectoryInfo directory = new DirectoryInfo(
        //        Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + fileName)));
        //    string jsonString = JsonSerializer.Serialize(Users);
        //    using (StreamWriter writer = new StreamWriter(directory.FullName))
        //    {
        //        writer.Write(jsonString);
        //    }
        //    Console.WriteLine("Json is written");
        //}

        public void WriteToJsons(List<User> Users, List<Tasks> TodoList)
        {
            //string fileName = "Users.json";
            //string currentDir = Environment.CurrentDirectory;
            //DirectoryInfo directory = new DirectoryInfo(
            //    Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + fileName)));

            string fullPath = GettingPath.GetPath("Users.json");

            Data data = new Data
            {
                DataUsers = Users,
               // DataTasks = TodoList
            };

            string jsonString = JsonSerializer.Serialize(data);

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.Write(jsonString);
            }

           // Console.WriteLine("Json is written");
        }

    }
}
