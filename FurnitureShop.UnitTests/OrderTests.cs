using System.Linq;
using FurnitureShop.Domain;
using NUnit.Framework;

namespace FurnitureShop.UnitTests
{
    [TestFixture]
    public class OrderTests
    {
        private Order _subject;
        private Stock _stock;
        private Item[] _items;
        private Item _desk;
        private Item _table;

        [SetUp]
        public void SetUp()
        {
            _items = new[] { _desk = new Item("desk", 25), _table = new Item("table", 35) };
            _stock = new Stock(_items);
            _subject = new Order(_stock);
        }

        [Test]
        public void Should_add_item_to_order()
        {
            Assert.True(_subject.AddItem(_desk.Name));
            Assert.That(_subject.Items, Is.EquivalentTo(new[] { _desk }));
            Assert.That(_stock.Items.Contains(_desk), Is.False);
        }

        [Test]
        public void Should_return_total_cost()
        {
            foreach (var item in _items)
                _subject.AddItem(item.Name);
            Assert.That(_subject.TotalPrice,Is.EqualTo(_items.Sum(i=>i.Price)));
        }
    }
}