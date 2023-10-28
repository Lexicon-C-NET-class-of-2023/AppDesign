using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.Rentals
{
    public class AddRental
    {
        public static string NewRental(char period)
        {
            //period '1' = day, '2' = week
            string howLong;
            bool invalid = true;
            int temp = 0;

            do
            {
                if (period == '1')
                {
                    if (temp < 7) Console.WriteLine("Basic accounts can't hire less than seven days");

                    Console.WriteLine(temp == 0 ? "\n\nHow long:" : "How long:");
                    howLong = Console.ReadLine();
                    temp = int.Parse(howLong);

                    if (howLong != "" && temp >= 7) invalid = false;
                }
                else
                {
                    Console.WriteLine("\n\nHow long:");
                    howLong = Console.ReadLine();
                    if (howLong != "") invalid = false;
                }
            } while (invalid);

            return $"{howLong}";
        }

        public static string NewRental()
        {
            string howLong;
            bool invalid = true;

            do
            {
                Console.WriteLine("\n\nHow long:");
                howLong = Console.ReadLine();

                if (howLong != "") invalid = false;
            } while (invalid);

            return $"{howLong}";
        }
    }
}
