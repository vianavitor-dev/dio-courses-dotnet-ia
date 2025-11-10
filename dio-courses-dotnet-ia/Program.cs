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
Console.Write("\n");

// 3. Dictionary
MyDictionary brazilStates = new MyDictionary();

brazilStates.Add("SP", "São pPaulooo");
brazilStates.Add("BA", "Bahia");
brazilStates.Add("MG", "Mina Gerais");

brazilStates.Show();

brazilStates.Remove("BA");
brazilStates.Show();

brazilStates.Modify("SP", "São Paulo");
brazilStates.Show();

brazilStates.Add("MG", "Mina Gerais");