using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.Accounts
{
    internal class AddAccount
    {
        public static string NewAccount()
        {
            string firstName;
            string lastName;
            string age;
            string city;
            string zipCode;
            string street;
            string phoneNr;
            string email;
            string type;
            bool invalid = true;

            do
            {
                Console.WriteLine("\n\nPlease enter your firstname:");
                firstName = Console.ReadLine();

                Console.WriteLine("\nPlease enter your lastname:");
                lastName = Console.ReadLine();

                Console.WriteLine("\nPlease enter your age:");
                age = Console.ReadLine();

                Console.WriteLine("\nPlease enter your city:");
                city = Console.ReadLine();

                Console.WriteLine("\nPlease enter your zip code:");
                zipCode = Console.ReadLine();

                Console.WriteLine("\nPlease enter your street:");
                street = Console.ReadLine();

                Console.WriteLine("\nPlease enter your phone number:");
                phoneNr = Console.ReadLine();

                Console.WriteLine("\nPlease enter your email:");
                email = Console.ReadLine();
                
                Console.WriteLine("\nPlease enter your type:");
                type = Console.ReadLine();

                if (firstName != "" || lastName != "" || age != "" || city != "" || zipCode != "" || street != "" || phoneNr != "" || email != "" || type != "") invalid = false;
                //if (firstName != "" || age != "") invalid = false;
            } while (invalid);

            //return $"{firstName}, {age}";
            return $"{firstName},{lastName},{age},{city},{zipCode},{street},{phoneNr},{email},{type}";
        }
    }
}
