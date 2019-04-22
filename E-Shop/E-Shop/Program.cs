using System;
using System.Collections.Generic;
using E_Shop.Models;
using System.Linq;
using System.Threading;

namespace E_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Product> products =ProductList.ProductList.GetAllProduct() ;
            //products.ForEach((x) => Console.WriteLine($"{x.Id}- {x.Name} - {x.Quantity} -Price: {x.Price} $ - Vendor: {x.Vendor}-Gender :{x.Gender}"));


                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome to the E-Shop Perfume.com, where you can get the best deals on perfumes for women and men from all the best discount designer brands. From Burberry, Calvin Klein, Giorgio Armani, Versace and NinaRicci");
                Console.WriteLine("Please enter your First Name");
                Customer Customer = new Customer();
                Customer.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter your Last Name");
                Customer.LastName = Console.ReadLine();
            

                Console.WriteLine("Please enter your Gender-Male or Female");
                string CustomerGender = Console.ReadLine().ToLower();
                 if (CustomerGender=="male")
                 {
                Customer.Gender = Gender.Male;
                 } else
                 {
                Customer.Gender = Gender.Female;
                 }

            Console.WriteLine($"Welcome {Customer.FirstName} {Customer.LastName} Here is the list of Parfume that we choose for You");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Thread.Sleep(2000);
            List<Product> CustomerGenderList = products
                                    .Where(x => x.Gender == Customer.Gender)
                                    .OrderBy(x => x.Price).ToList();
             Product.PrintListProduct(CustomerGenderList);
            Console.WriteLine("-------------------------------------------------------------------------------");

            Thread.Sleep(3000);
            Console.WriteLine($"If you want to see all Product enter Yes or No");
            string CustomerChoose = Console.ReadLine().ToLower();
            if (CustomerChoose == "yes")
            {
                Product.PrintListProduct(products);
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------------");


            }


            Thread.Sleep(3000);
            Console.WriteLine("Let start your Shopping :)");
            Console.WriteLine("You can choose vendor from our List");
            Console.WriteLine("---------------VENDORS-----------------------------------------------");
            var VendorList = products
                                    .Select(x => x.Vendor)
                                    .Distinct()
                                    .ToList();
            foreach (var item in VendorList)
            {
                Console.WriteLine(item);
            }

                      
            Console.WriteLine("------------------------------------------------------------------------------");
                        
            Order order = new Order();
            Console.WriteLine("Type the name of the Vendor");
            string vendorName = Console.ReadLine();
            var vendorProducts = products
                               .Where(x => x.Vendor.ToString() == vendorName)
                               .ToList();
            Product.PrintListProduct(vendorProducts);
            while (true)
            {
                Console.WriteLine($"Please enter the Id of the Product  to add in your Cart");
                int ProductId = int.Parse(Console.ReadLine());
                var product1 = vendorProducts.Where(x => x.Id == ProductId).FirstOrDefault();
                Console.WriteLine($" Price: { product1.Price}");
                Console.WriteLine($"Please enter Quantity of the Product  ");
                int ProductQuantity = int.Parse(Console.ReadLine());
                if (ProductQuantity > product1.Quantity)
                {
                    Console.WriteLine("We do not have enough of that product." +
                                    "Please reduce the quantity you are looking for");
                }
                else
                {


                    order.AddOrderLine(product1, ProductQuantity);
                    Console.WriteLine("If you want to add more product enter Yes or No");
                    string CustomerChoose2 = Console.ReadLine().ToLower();
                    if (CustomerChoose2 == "no")
                    {
                        Console.WriteLine("Do you want to remove some product from the order? Yes or No?");
                         string removeAnswer = Console.ReadLine().ToLower();
                       
                       
                           if (removeAnswer == "yes")
                            {
                                Console.WriteLine("Plese type the Product Id that you want to remove");
                                int idForRemove = int.Parse(Console.ReadLine());
                                var productsOrder = products
                                               .Where(x => x.Id == product1.Id)
                                               .FirstOrDefault();
                               
                                order.RemoveOrderLine(productsOrder, idForRemove);
                            continue;
                                
                            }
                            else 
                            {
                                double Total = order.OrderTotal();
                                Console.WriteLine($"Your total amount  to pay is: {Total} ");
                                break;
                            }
                        }

                    }

                    }
            Console.ReadLine();

        }
       

            }





          
            
        }

        
       

