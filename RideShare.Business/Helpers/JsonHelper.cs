using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RideShare.Business.Helpers
{
    public class JsonHelper
    {
        private static string filePath = @"C:\\travels.json";
        public static List<T> ReadJson<T>()
        {
            var jsonData = "";
            // Read existing json data
            try
            {
                 jsonData = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                jsonData = "[{}]";
                System.IO.File.WriteAllText(filePath,jsonData);
            }
            
            // De-serialize to object or create new list
            var list = JsonSerializer.Deserialize<List<T>>(jsonData)
                                  ?? new List<T>();

            return list;
        }

        public static void WriteJson<T>(List<T> list)
        {
            var jsonData = JsonSerializer.Serialize(list);
            // Update json data string
            System.IO.File.WriteAllText(filePath, jsonData);
        }
    }
}
