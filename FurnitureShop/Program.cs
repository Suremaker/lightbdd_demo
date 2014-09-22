using System;
using FurnitureShop.Domain;

namespace FurnitureShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stock = new Stock(new Item("desk", 25), new Item("shelf", 32), new Item("table", 42));
            var order = new Order(stock);
            order.AddItem("table");
            order.AddItem("shelf");

            PrintOrderDetails(order);

            Console.ReadKey();
        }

        private static void PrintOrderDetails(Order order)
        {
            Console.WriteLine("Items:");
            foreach (var item in order.Items)
                Console.WriteLine("  {0}: £{1}", item.Name, item.Price);

            Console.WriteLine("Total: {0}",order.TotalPrice);
        }
    }
}