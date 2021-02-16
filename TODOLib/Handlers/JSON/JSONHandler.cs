using System;
using System.Text.Json;
using System.Collections.Generic;
using TODOLib.Entities;
using System.IO;

namespace TODOLib.Handlers.JSON
{
    public static class JSONHandler
    {
        public static void SaveJson(string json)
        {
            FileHandler.WriteToFile("Database.json", json);
        }

        public static string LoadJson()
        {
            return FileHandler.ReadFromFile("Database.json");        
        }

    }
}
