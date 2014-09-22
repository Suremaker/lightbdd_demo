using System.Collections.Generic;
using System.Linq;

namespace FurnitureShop.Domain
{
    public class Order
    {
        private readonly Stock _stock;
        private readonly List<Item> _items = new List<Item>();

        public Order(Stock stock)
        {
            _stock = stock;
        }

        public bool AddItem(string name)
        {
            var item = _stock.Remove(name);
            if (item == null)
                return false;
            _items.Add(item);
            return true;
        }

        public IEnumerable<Item> Items { get { return _items; } }
        public decimal TotalPrice { get { return _items.Sum(i => i.Price); } }
    }
}