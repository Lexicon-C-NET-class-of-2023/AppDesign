using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.Accounts
{
    internal class ShowAccounts
    {
        public static void ShowAllAccounts(List<dynamic> accounts)
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
                if (account is Account.AccountBasic) Console.WriteLine("Discount " + account.Discount);
                if (account is Account.AccountPrime) Console.WriteLine("Bonus " + account.Bonus);

                //if (account is Accounts.) Console.WriteLine("Discount " + account.Discount);
                //if (account is Accounts.AccountPrime) Console.WriteLine("Bonus " + account.Bonus);
                Console.WriteLine();
            }
        }
    }
}
