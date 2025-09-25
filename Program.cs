/*
    HOW TO USE A CLASS:
    1. Call the namespace of the class
    2. Instantiate the class as a new object
*/

// 1. calling the namespace of the Person class
using dio_courses_dotnet_ia.SintaxIndentation.Models;

// 2. creating a new object
Person person1 = new Person();
// Person person2 = new() { Name = "George", Age = 14 }; // another way to create a new object

person1.Name = "Vitor";
person1.Age = 20;

person1.IntroduceYourself();