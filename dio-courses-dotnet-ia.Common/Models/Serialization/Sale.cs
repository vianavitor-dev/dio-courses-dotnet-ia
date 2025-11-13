using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dio_courses_dotnet_ia.Common.Models.Serialization
{
    public class Sale
    {
        public Sale(int id, string product, decimal price, DateTime soldAt)
        {
            Id = id;
            Product = product;
            Price = price;
            SoldAt = soldAt;
        }

        public int Id { get; set; }

        [JsonProperty("Product_Name")]
        public string Product { get; set; }
        
        public decimal Price { get; set; }

        public DateTime SoldAt { get; set; }
    }
}