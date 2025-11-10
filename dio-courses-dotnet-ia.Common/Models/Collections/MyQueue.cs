using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Common.Models.Collections
{
    public class MyQueue
    {
        public Queue<string> Items { get; set; } = new Queue<string>();

        // Add item to the end of the queue
        public void Add(string item)
        {
            Items.Enqueue(item);
        }

        // Remove and return the item at the front of the queue
        public string Remove()
        {   
            return Items.Dequeue();
        }

        public void Show()
        {
            Console.WriteLine("MY QUEUE ");

            foreach (string element in Items)
            {   
                Console.WriteLine("* " + element);
            }
        }
    }
}