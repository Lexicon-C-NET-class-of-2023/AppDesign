namespace Layers.Models
{
    public static class Account
    {
        public class Shared
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
            public string? Type { get; set; }
        }

        public class Temp : Shared
        {
            public decimal Discount { get; set; }
            public decimal Bonus { get; set; }
        }

        public class AccountBasic : Shared
        {
            public decimal Discount { get; set; }
        }

        public class AccountPrime : Shared
        {
            public decimal Bonus { get; set; }
        }
    }
}
