using System.Collections.Generic;

namespace FurnitureShop.Domain
{
    public class Stock
    {
        private readonly List<Item> _items;

        public Stock(params Item[] items)
        {
            _items = new List<Item>(items);
        }

        public IEnumerable<Item> Items { get { return _items; } }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public Item Remove(string name)
        {
            var item = _items.Find(i => i.Name == name);
            if (item != null)
                _items.Remove(item);
            return item;
        }
    }
}
