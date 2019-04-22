using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models
{
  public  class Product
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Vendor  Vendor{ get; set; }
        public Gender Gender { get; set; }
        public List<Product> products { get; set; }
        public Product(int id,string name,int quantity, double price,Vendor vendor,Gender gender)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Vendor = vendor;
            Gender = gender;
        }

        public Product()
        {
        }

        public static void PrintListProduct(List<Product>products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}-{product.Name}-{product.Quantity}-{product.Price}-{product.Vendor}-{product.Gender}");
            }
        }

       
    }
}
