using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Common.Models.Collections
{
    public class MyStack
    {
        public Stack<int> Numbers { get; set; } = new Stack<int>();

        // Add num to the beginning of the stack
        public void Add(int num)
        {
            Numbers.Push(num);
        }

        // Remove the last num of the stack and return it
        public int Remove()
        {
            return Numbers.Pop();
        }

        public void Show()
        {
            Console.WriteLine("MY STACK ");

            foreach (int element in Numbers)
            {   
                Console.WriteLine("* " + element);
            }
        }
    }
}