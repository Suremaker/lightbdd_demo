using System.Linq;
using FurnitureShop.Domain;
using NUnit.Framework;
using LightBDD;

namespace FurnitureShop.AcceptanceTests.Features
{
    public partial class Selling_items : FeatureFixture
    {
        private Stock _stock;
        private Order _order;
        private const string _itemName = "desk";

        [SetUp]
        public void SetUp()
        {
            _stock = new Stock();
        }

        private void Given_a_item_is_available_on_stock()
        {
            _stock.AddItem(new Item(_itemName, 37));
        }

        private void When_order_is_placed_for_this_item()
        {
            _order = new Order(_stock);
            _order.AddItem(_itemName);
        }

        private void Then_order_is_successful()
        {
            Assert.That(_order.Items.Any(i => i.Name == _itemName), Is.True, "Order does not contain expected item");
        }

        private void And_item_is_removed_from_stock()
        {
            Assert.That(_stock.Items.Any(i => i.Name == _itemName), Is.False, "The expected item is still on stock");
        }
    }
}