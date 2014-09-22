using System;
using System.Collections.Generic;

namespace FurnitureShop.Domain
{
    public class CustomerDatabase
    {
        private readonly IDictionary<string, CustomerDetails> _customers = new Dictionary<string, CustomerDetails>();

        public string Add(CustomerDetails details)
        {
            if (string.IsNullOrWhiteSpace(details.Name) || string.IsNullOrWhiteSpace(details.Surname) || string.IsNullOrWhiteSpace(details.Address))
                throw new ArgumentException("All of customer details are required");
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