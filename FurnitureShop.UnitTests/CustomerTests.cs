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
            var details = new CustomerDetails("Smith", "John");
            details.SetAddress("High St. 27, AB1 2CD, London");
            var id = _subject.Add(details);
            Assert.That(id, Is.Not.Null);
            Assert.That(_subject.GetById(id), Is.SameAs(details));
        }
    }
}