namespace AddressBookApp.Models.Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }

    }
}
