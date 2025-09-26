using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.ArithmeticOperators
{
    public class Calculator
    {
        public void Sum(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public void Sub(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public void Divide(int x, int y)
        {
            Console.WriteLine($"{x} / {y} = {x / y}");
        }

        public void Multiply(int x, int y)
        {
            Console.WriteLine($"{x} * {y} = {x * y}");
        }

        public void Pow(int x, int y)
        {
            Console.WriteLine($"{x} ^ {y} = {Math.Pow(x, y)}");
        }

        public void Sine(double degree)
        {
            double radian = degree * Math.PI / 180;
            double sine = Math.Sin(radian);

            Console.WriteLine($"sine of {degree}° = {Math.Round(sine, 4)}");
        }

        public void Cosine(double degree)
        {
            double radian = degree * Math.PI / 180;
            double cosine = Math.Cos(radian);

            Console.WriteLine($"cosine of {degree}° = {Math.Round(cosine, 4)}");
        }

        public void Tangent(double degree)
        {
            double radian = degree * Math.PI / 180;
            double tangent = Math.Tan(radian);

            Console.WriteLine($"tangent of {degree}° = {Math.Round(tangent, 4)}");
        }


        public void SquareRoot(double x)
        {
            double result = Math.Sqrt(x);
            Console.WriteLine($"square root of {x} = {Math.Round(Math.Sqrt(x), 4)}");
        }
    }
}