/*
    * TUPLE
*/

// Creating a Tuple with implicit variable names
//ValueTuple<int, string, string> personData1 = (1, "Vitor", "Viana");

// Using the Create method
// var withCreateMethod = Tuple.Create(1, "Vitor", "Viana");

// Creating a Tuple by passing the variable names
// using dio_courses_dotnet_ia.Common.Models.Tuple;

// (int Id, string FirstName, string LastName) personData2 = (1, "Joao", "Silva");

// // Showing the datas
// // Console.WriteLine($"Id: {personData1.Item1}");
// // Console.WriteLine($"First name: {personData1.Item2}");
// // Console.WriteLine($"Last name: {personData1.Item3}");

// Console.WriteLine($"Id: {personData2.Id}");
// Console.WriteLine($"First name: {personData2.FirstName}");
// Console.WriteLine($"Last name: {personData2.LastName}");
// Console.WriteLine();

// // Read a file and returns a Tuple type
// MyFileReader reader = new MyFileReader();
// var (success, rows, rowsCount) = reader.ReadFile("files/data.txt");

// if (success)
// {
//     Console.WriteLine($"Linhas retornadas: {rowsCount}");

//     foreach (string row in rows)
//     {
//         Unknown
//     }
//     Console.WriteLine();
// }
// else
// {
//     Console.WriteLine("Não foi possível ler o arquivo");
// }

// Using the Discontructor + Tuple type for the return
using dio_courses_dotnet_ia.Common.Models;

Person2 p2 = new Person2("Vitor", "Viana");
(string name, string lastName) = p2;

Console.WriteLine($"Name: {name}\tLast Name: {lastName}");

/*
    * COLLECTIONS 
*/
// 1. Queue (FIFO)
// MyQueue items = new MyQueue();
// items.Add("pokemon");
// items.Add("digimon");

// items.Show();
// Console.WriteLine($"-> removing {items.Remove()} from the queue");

// items.Show();
// Console.Write("\n");

// // 2. Stack (LIFO)
// MyStack numbers = new MyStack();
// numbers.Add(3);
// numbers.Add(1);
// numbers.Add(5);
// numbers.Add(9);

// numbers.Show();
// Console.WriteLine($"-> removing {numbers.Remove()} from the stack");

// numbers.Show();
// Console.Write("\n");

// // 3. Dictionary
// MyDictionary brazilStates = new MyDictionary();

// brazilStates.Add("SP", "São pPaulooo");
// brazilStates.Add("BA", "Bahia");
// brazilStates.Add("MG", "Mina Gerais");

// brazilStates.Show();

// brazilStates.Remove("BA");
// brazilStates.Show();

// brazilStates.Modify("SP", "São Paulo");
// brazilStates.Show();

// brazilStates.Add("MG", "Mina Gerais");