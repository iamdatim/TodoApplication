using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace newToDo
{
    internal class GettingPath
    {
        public static string GetPath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + fileName)));
            return directory.FullName;
        }
    }
}
