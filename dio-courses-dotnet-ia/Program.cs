/*
    HOW TO USE A CLASS:
    1. Call the namespace of the class
    2. Instantiate the class as a new object
*/

// 1. calling the namespace of the Person class
using dio_courses_dotnet_ia.Common.Models;

// // 2. creating a new object
// Person person1 = new Person();
// // Person person2 = new() { Name = "George", Age = 14 }; // another way to create a new object

// person1.Name = "Vitor";
// person1.Age = 20;

// person1.IntroduceYourself();


// /*
//     Using the data type learned in the course video
// */
// Product product1 = new()
// {
//     Name = "Apple",
//     Price = 5.2M,
//     CanBeSold = true,
//     // change this value to 0 to test what happens if the Product has passed the expiration date
//     ExpirationDate = DateTime.Now.AddDays(2.1) 
// };
// product1.ShowInformation();

// product1.AddQuantity(4);

// if (product1.IsItExpired())
// {   
//     product1.CanBeSold = false;
// }

// product1.ShowInformation();


// /*
//     Using the Calculator.cs to apply what I learned in the arithmetic operation class in the couse
// */
// Calculator calculator = new();

// Console.WriteLine("\nCALCULATOR \n===========================");
// calculator.Sum(5, 8);
// calculator.Sub(9, 3);
// calculator.Divide(4, 6);
// calculator.Multiply(12, 7);
// calculator.Pow(2, 6);

// calculator.Sine(30);
// calculator.Cosine(30);
// calculator.Tangent(30);
// calculator.SquareRoot(302);

// Console.WriteLine(); // used to get more space on the edges


/*
    Using the InteractiveMenu.cs to apply what I learned in the loops class in the course
*/
InteractiveMenu menu = new();
string? chosenAction;

do
{
    chosenAction = menu.EnterAction();
    menu.MenuAction(chosenAction);

} while (chosenAction != "4"); // 4 is the exit command

