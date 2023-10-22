using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.Rentals
{
    public class AddRental
    {
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
