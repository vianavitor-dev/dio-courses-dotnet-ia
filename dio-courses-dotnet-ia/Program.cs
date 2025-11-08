using dio_courses_dotnet_ia.Common.Models.ManagingValues;
using System.Globalization;

decimal moneyAmount = 1234.56M;

Money money = new Money { Amount = moneyAmount };

// Show amount in default culture (en-US)
money.showFormatedAmount(); // default format
money.MyCultureInfo = new System.Globalization.CultureInfo("en-US");
money.showFormatedAmount("C4"); // custom format with 4 decimal place

/* 
    More formats examples:
*/
double procentage = .2567;
Console.WriteLine(procentage); // Default format
Console.WriteLine(procentage.ToString("P")); // Percentage format

int number = 123456789;
Console.WriteLine(number); // Default format
Console.WriteLine(number.ToString("###-###-###")); // Custom format

DateTime date = DateTime.Now;
Console.WriteLine(date); // Default format
Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm")); // Brazilian format

String dateString = "2024-06-15 14:30";

bool sucess = DateTime.TryParseExact(
    dateString,
    "yyyy-MM-dd HH:mm",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateTime resultDate
);

if (!sucess)
{
    Console.WriteLine("Invalid date format.");
    return;
}

Console.WriteLine("result date: " + resultDate);