using Layers.Controllers;
using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views
{
    public static class Menu
    {
        public static void AppMenu()
        {
            string[] choices = { "Press 1 to Create Account", "Press 2 to Rent" };
            char choice = GetChoice();

            if (choice == '1')
            {
                Console.WriteLine("You have chosen Create Account");
                AccountController myAccountController = new AccountController();
            }
            else
            {
                Console.WriteLine("You have chosen to Rent");
                //RentController myRentController = new RentController();
            }
        }


        //public static char GetChoice("Array of choices", "ConditionalAttribute to fulfill")
        public static char GetChoice()
        {
            char key = 'a';

            while (!(key is '1' or '2'))
            {
                Console.WriteLine("Press 1 to Create Account");
                Console.WriteLine("Press 2 to Rent");
                //foreach (var item in choices) Console.WriteLine(item); 

                key = Console.ReadKey().KeyChar;
            }
            return key;
        }
    }
}