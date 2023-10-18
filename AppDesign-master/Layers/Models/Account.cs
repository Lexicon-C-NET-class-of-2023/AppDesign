using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models
{
    public class Account
    {
        public int Id { get; set; }
        public DateTime Registered { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int age { get; set; }
        public string? Address { get; set; }

        public int Phonenumber { get; set; }
        public decimal Balance { get; set; }
        public string? Email { get; set; }
    }
}
