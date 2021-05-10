using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAssignment9
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual List<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Redmi Note 5",
                    Quantity  = 13,
                    Price = 12000
                },
                new Product
                {
                    Id = 2,
                    Name = "Apple Iphone 12 Pro Max",
                    Quantity  = 100,
                    Price = 130000
                },
                new Product
                {
                    Id = 3,
                    Name = "Oneplus Bluetooth WZ",
                    Quantity  = 50,
                    Price = 2000
                }
            };

            return products;
        }
    }


}
