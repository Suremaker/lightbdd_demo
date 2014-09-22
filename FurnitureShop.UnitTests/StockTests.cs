using FurnitureShop.Domain;
using NUnit.Framework;

namespace FurnitureShop.UnitTests
{
    [TestFixture]
    public class StockTests
    {
        private Stock _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new Stock();
        }

        [Test]
        public void Should_add_item_to_stock()
        {
            var item = new Item("desk", 32);
            var item2 = new Item("shelf", 27);
            _subject.AddItem(item);
            _subject.AddItem(item2);

            Assert.That(_subject.Items, Is.EquivalentTo(new[] { item, item2 }));
        }

        [Test]
        public void Should_remove_item_from_stock()
        {
            var item = new Item("desk", 32);
            var item2 = new Item("shelf", 27);
            _subject.AddItem(item);
            _subject.AddItem(item2);

            var removedItem = _subject.Remove("desk");
            Assert.That(removedItem, Is.SameAs(item));
            Assert.That(_subject.Items, Is.EquivalentTo(new[] { item2 }));
        }
    }
}