using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Logical path to this directory
namespace dio_courses_dotnet_ia.Common.Models
{
    public class Person2
    {
        public Person2()
        {
            Name = "Unknown";
            LastName = "";
        }

        public Person2(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public void Deconstruct(out string name, out string lastName)
        {
            name = Name;
            lastName = LastName;
        }

        private string _name;
        private int _age;

        public int Age {
            get => _age;

            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Invalid age");
                }

                _age = value;
            }
        
        }

        public string Name
        {
            // body express (lambda)
            get => _name.ToUpper();

            set
            {
                if (value == "" || value == null)
                {
                    throw new ArgumentException("The name field must be fill in");
                }

                _name = value;
            }
        }

        public string LastName { get; set; }

        // Read only propertie
        public string CompleteName => $"{Name} {LastName}".ToUpper();
        
        public void IntroduceYourself()
        {
            Console.WriteLine($"Hi, my name's {CompleteName}, I'm {Age} years old");
        }
    }
}