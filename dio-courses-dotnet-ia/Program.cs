// Collections
// 1. Queue (FIFO)
using dio_courses_dotnet_ia.Common.Models.Collections;

MyQueue items = new MyQueue();
items.Add("pokemon");
items.Add("digimon");

items.Show();
Console.WriteLine($"-> removing {items.Remove()} from the queue");

items.Show();
Console.Write("\n");

// 2. Stack (LIFO)
MyStack numbers = new MyStack();
numbers.Add(3);
numbers.Add(1);
numbers.Add(5);
numbers.Add(9);

numbers.Show();
Console.WriteLine($"-> removing {numbers.Remove()} from the stack");

numbers.Show();
