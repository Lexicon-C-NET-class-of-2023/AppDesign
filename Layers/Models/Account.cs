namespace Layers.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Registered { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Phonenumber { get; set; }
        public string? Email { get; set; }
    }
}