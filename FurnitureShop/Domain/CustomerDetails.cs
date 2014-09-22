namespace FurnitureShop.Domain
{
    public class CustomerDetails
    {
        public string Id { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public CustomerDetails(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}