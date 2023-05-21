using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using ToDoApp_Methods;

namespace newToDo
{
    internal class ReadFromJson
    {
        public List<User> ReadFromJsons(string fullPath)
        {
            string jsonContent = File.ReadAllText("Users.json");
            return JsonSerializer.Deserialize<List<User>>(jsonContent);
        }
    }
}
