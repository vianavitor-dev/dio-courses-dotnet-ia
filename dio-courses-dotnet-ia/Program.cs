// Collections
// 1. Queue (FIFO)
using dio_courses_dotnet_ia.Common.Models.Collections;

MyQueue items = new MyQueue();
items.Add("pokemon");
items.Add("digimon");

items.Show();
Console.WriteLine($"-> removing {items.Remove()} from the queue");

items.Show();