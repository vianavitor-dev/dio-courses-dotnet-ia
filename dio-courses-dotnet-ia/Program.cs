using dio_courses_dotnet_ia.Common.Models.ManagingValues;

decimal moneyAmount = 1234.56M;

Money money = new Money { Amount = moneyAmount };

// Show amount in default culture (en-US)
money.showFormatedAmount(); // default format
money.MyCultureInfo = new System.Globalization.CultureInfo("pt-BR");
money.showFormatedAmount("C4"); // custom format with 4 decimal place


