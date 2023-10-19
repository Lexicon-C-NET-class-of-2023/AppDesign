using Layers.Models;

namespace Layers.Views
{
    public static class ShowAccounts
    {
        public static void ShowAllAccounts(List<Account> accounts)
        {
            Console.WriteLine("\n\n\nRegistered Accounts\n");
            foreach (var account in accounts)
            {
                Console.WriteLine("Id: " + account.Id);
                Console.WriteLine("Registered: " + account.Registered);
                Console.WriteLine("First Name: " + account.FirstName);
                Console.WriteLine("Last Name: " + account.LastName);
                Console.WriteLine("Age: " + account.Age);
                Console.WriteLine("City: " + account.City);
                Console.WriteLine("Zipcode: " + account.ZipCode);
                Console.WriteLine("Street: " + account.Street);
                Console.WriteLine("Phonenumber: " + account.Phonenumber);
                Console.WriteLine("Email: " + account.Email);
                Console.WriteLine();
            }
        }
    }
}