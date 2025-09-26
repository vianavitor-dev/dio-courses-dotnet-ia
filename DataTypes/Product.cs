using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.DataTypes
{
    public class Product
    {
        public int Quantity { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool CanBeSold { get; set; }

        public DateTime ExpirationDate { get; set; }

        /*
            Verify whether the product’s expiration date has been reached
        */
        public bool IsItExpired()
        {
            DateTime now = DateTime.Now;

            return now.CompareTo(ExpirationDate) >= 0;
        }

        public void AddQuantity(int num)
        {
            Quantity += num;
        }

        /*
            Write the Product datas into the console
        */
        public void ShowInformation()
        {   
            // Transforming the date into string and formatting it
            string formattedDate = ExpirationDate.ToString("dd/MM/yyyy HH:mm");

            Console.WriteLine(
                "\nPRODUCT" +
                "\n================================ \n" +
                $"Name: {Name} \nPrice: {Price} \nCanBeSold: {CanBeSold} \nExpirationDate: {formattedDate}"
            );
        }
    }
}