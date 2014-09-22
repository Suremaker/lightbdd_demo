using LightBDD;
using NUnit.Framework;

namespace FurnitureShop.AcceptanceTests.Features
{
    [FeatureDescription(
@"In order to sell items to customer
As a seller
I want to place an order for customer
So that items could be sold")]
    [Label("FEAT-2")]
    [TestFixture]
    public partial class Selling_items
    {
        [Test]
        [Label("Ticket-3")]
        public void Items_should_be_removed_from_stock_when_an_order_is_placed()
        {
            Runner.RunScenario(
                Given_a_item_is_available_in_stock,
                When_order_is_placed_for_this_item,
                Then_order_is_successful,
                And_item_is_removed_from_stock);
        }
    }
}