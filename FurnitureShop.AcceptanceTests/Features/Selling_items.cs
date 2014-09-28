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

        [Test]
        [Label("Ticket-4")]
        public void It_should_be_possible_to_see_the_total_price_of_order()
        {
            Runner.RunScenario(
                Given => An_item_with_price_GBP_is_available_on_stock("book_shelf", 45),
                And => An_item_with_price_GBP_is_available_on_stock("wooden_desk", 62),
                When => Order_is_placed_for_item("book_shelf"),
                And => Order_is_placed_for_item("wooden_desk"),
                Then => Total_price_of_order_is_AMOUNT_GBP(107));

        }
    }
}