using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Utilities
{
    public static class JsonHandler
    {
        public static T DeserializeJsonFromFile<T>(string filePath)
        {
            var jsonData = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, filePath));
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static List<T> DeserializeJsonArrayFromFile<T>(string filePath)
        {
            var jsonData = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, filePath));
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
