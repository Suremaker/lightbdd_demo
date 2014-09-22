using FurnitureShop.Domain;
using NUnit.Framework;

namespace FurnitureShop.AcceptanceTests.Features
{
    /*
FEAT-1 Customer details
In order to serve customers effectively
As a seller
I want to save customers details,
So that I will not have to do it every time
     */
    [TestFixture]
    public class Customer_details
    {
        private CustomerDetails _customer;
        private CustomerDatabase _database;
        private string _customerId;

        [Test]
        //Ticket-1
        public void It_should_be_possible_to_add_customer_details_to_database()
        {
            Given_a_new_customer();
            When_customer_name_is_entered();
            And_new_customer_address_is_entered();
            And_new_customer_addition_is_requested();
            Then_new_ID_is_associated_to_the_customer();
            And_entered_details_are_associated_to_returned_customer_ID();
        }

        [Test]
        //Ticket-2
        public void It_should_be_possible_to_retrieve_existing_customer_details()
        {
            Given_an_existing_customer();
            When_customer_ID_is_entered();
            Then_associated_customer_details_are_being_returned();
        }

        [SetUp]
        public void SetUp()
        {
            _database = new CustomerDatabase();
            _customer = null;
        }

        private void Given_a_new_customer()
        {
            _customer = new CustomerDetails();
        }

        private void When_customer_name_is_entered()
        {
            _customer.SetName("Smith", "John");
        }

        private void And_new_customer_address_is_entered()
        {
            _customer.SetAddress("High St. 27, AB1 2CD, London");
        }

        private void And_new_customer_addition_is_requested()
        {
            _customerId = _database.Add(_customer);
        }

        private void Then_new_ID_is_associated_to_the_customer()
        {
            Assert.That(_customerId, Is.Not.Null);
        }

        private void And_entered_details_are_associated_to_returned_customer_ID()
        {
            var details = _database.GetById(_customerId);
            Assert.That(details, Is.Not.Null);
            Assert.That(details.Name, Is.EqualTo(_customer.Name));
            Assert.That(details.Surname, Is.EqualTo(_customer.Surname));
            Assert.That(details.Address, Is.EqualTo(_customer.Address));
        }

        private void Given_an_existing_customer()
        {
            _customerId = _database.Add(new CustomerDetails().SetName("Black", "Jack").SetAddress("Some Street, FE3 6FF, London"));
        }

        private void When_customer_ID_is_entered()
        {
            _customer = _database.GetById(_customerId);
        }

        private void Then_associated_customer_details_are_being_returned()
        {
            Assert.That(_customer.Name, Is.EqualTo("Jack"));
            Assert.That(_customer.Surname, Is.EqualTo("Black"));
            Assert.That(_customer.Address, Is.EqualTo("Some Street, FE3 6FF, London"));
        }
    }
}