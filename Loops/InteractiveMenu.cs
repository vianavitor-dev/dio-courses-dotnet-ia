using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Loops
{
    public class InteractiveMenu
    {
        /*
            Ask the user to select an action among the given ones, and return the chosen action
        */
        public string  EnterAction()
        {
            Console.WriteLine("Choose an action amoung these: \n1- Create User \n2- Search User \n3- Delete User \n4- Exit");
            Console.WriteLine("Enter the number on the left to select an action! ");

            string  chosenAction = Console.ReadLine()?.Trim() ?? "0";
            return chosenAction;
        }

        /* 
            Given the chosen action, call its corresponding event
        */
        public void MenuAction(string? chosenAction)
        {
            // convert the string chosen action to an int type
            int action;
            int.TryParse(chosenAction, out action);

            Console.Clear();

            // possible events
            switch (action)
            {
                case 1:
                    Console.WriteLine("+ Creating user...");
                    break;
                case 2:
                    Console.WriteLine("+ Searching user...");
                    break;
                case 3:
                    Console.WriteLine("+ Deleting user...");
                    break;
                case 4:
                    Console.WriteLine("+ exit");
                    break;
                default:
                    Console.WriteLine($"- the action #{action} does not exist");
                    break;
            }
        }
    }
}