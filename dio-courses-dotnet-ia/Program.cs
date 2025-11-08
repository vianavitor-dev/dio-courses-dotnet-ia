using dio_courses_dotnet_ia.Common.Models;

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

