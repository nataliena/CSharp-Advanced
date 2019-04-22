using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    public class Order
    {
        private List<OrderLine> _orderLines = new List<OrderLine>();
        public  void AddOrderLine(Product product,int quantity )
        {
            OrderLine line = new OrderLine();
            line.ProductId = product.Id;
            line.ProductName = product.Name;
            line.ProductQuantity = quantity;
            line.ProductPrice = product.Price;
            _orderLines.Add(line);
        }

        public double OrderTotal()
        {
            double total = 0;
            foreach (var orderLine in _orderLines)
            {
                total += orderLine.OrderLineTotal();
            }
            return total;
        }

        public void RemoveOrderLine(Product product,int id)
        {
            OrderLine line = new OrderLine();
            line.ProductId = id;
            line.ProductName = product.Name;
            line.ProductQuantity = product.Quantity;
            line.ProductPrice = product.Price;
            _orderLines.Remove(line);
        }



        private class OrderLine
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int ProductQuantity { get; set; }
            public double ProductPrice { get; set; }
            public double OrderLineTotal()
            {
                return ProductPrice * ProductQuantity;
            }




        }
    }

}
