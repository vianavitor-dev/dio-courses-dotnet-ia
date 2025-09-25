using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Logical path to this directory
namespace dio_courses_dotnet_ia.SintaxIndentation.Models
{
    public class Person()
    {
        public int Age { get; set; }

        public string Name { get; set; }

        // Person p1 = new Person();
        // p1.IntroduceYourself();
        public void IntroduceYourself()
        {
            Console.WriteLine($"Hi, my name's {Name}, I'm {Age} years old");
        }
    }
}