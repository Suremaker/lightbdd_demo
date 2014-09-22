using System;
using FurnitureShop.Domain;
using NUnit.Framework;

namespace FurnitureShop.UnitTests
{
    [TestFixture]
    public class CustomerTests
    {
        private CustomerDatabase _subject;

        [SetUp]
        public void SetUp()
        {
            _subject = new CustomerDatabase();
        }

        [Test]
        public void Should_add_customer()
        {
            var details = new CustomerDetails()
                .SetName("Smith", "John")
                .SetAddress("High St. 27, AB1 2CD, London");

            var id = _subject.Add(details);
            Assert.That(id, Is.Not.Null);
            Assert.That(_subject.GetById(id), Is.SameAs(details));
        }

        [Test]
        public void Should_not_add_customer_if_details_are_not_provided()
        {
            AssertExceptionIsThrown(new CustomerDetails());
            AssertExceptionIsThrown(new CustomerDetails().SetName("Smith", "John"));
            AssertExceptionIsThrown(new CustomerDetails().SetAddress("High St. 27, AB1 2CD, London"));
        }

        private void AssertExceptionIsThrown(CustomerDetails details)
        {
            var ex = Assert.Throws<ArgumentException>(() => _subject.Add(details));
            Assert.That(ex.Message, Is.EqualTo("All of customer details are required"));
        }
    }
}