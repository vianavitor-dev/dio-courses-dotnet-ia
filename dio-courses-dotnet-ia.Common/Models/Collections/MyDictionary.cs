using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Common.Models.Collections
{
    public class MyDictionary
    {
        Dictionary<string, string> Dict { get; set; } = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            Dict.Add(key, value);
        }

        public void Remove(string key)
        {
            Dict.Remove(key);
        }

        public void Modify(string key, string newValue)
        {
            Dict[key] = newValue;
        }

        public void Show()
        {
            Console.WriteLine("MY DICTIONARY: ");

            foreach (var item in Dict)
            {
                Console.WriteLine($"* key: {item.Key}, value: {item.Value}");
            }
        }
    }
}