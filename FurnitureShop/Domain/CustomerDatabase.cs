using System.Collections.Generic;

namespace FurnitureShop.Domain
{
    public class CustomerDatabase
    {
        private readonly IDictionary<string, CustomerDetails> _customers = new Dictionary<string, CustomerDetails>();

        public string Add(CustomerDetails details)
        {
            details.SetId(details.Id ?? GenerateKey());
            _customers.Add(details.Id, details);
            return details.Id;
        }

        private string GenerateKey()
        {
            return "C" + _customers.Count.ToString("D6");
        }

        public CustomerDetails GetById(string id)
        {
            CustomerDetails details;
            return _customers.TryGetValue(id, out details) ? details : null;
        }
    }
}