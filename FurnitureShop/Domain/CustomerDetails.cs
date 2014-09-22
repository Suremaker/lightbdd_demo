namespace FurnitureShop.Domain
{
    public class CustomerDetails
    {
        public string Id { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public CustomerDetails SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public CustomerDetails SetId(string id)
        {
            Id = id;
            return this;
        }

        public CustomerDetails SetName(string surname, string name)
        {
            Surname = surname;
            Name = name;
            return this;
        }
    }
}