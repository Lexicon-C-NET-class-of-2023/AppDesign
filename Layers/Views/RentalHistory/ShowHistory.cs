using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.RentalHistory
{
    public class ShowHistory
    {
        public static void ShowCompleteHistory(List<Rental> rentals)
        {
            Console.WriteLine(rentals.Count() > 0 ? "\n\n\nComplete Rental History\n" : "\n\n\nThere are no Rental History yet\n");
            foreach (var rental in rentals)
            {
                Console.WriteLine("Id: " + rental.Id);
                Console.WriteLine("RentedByAccountId: " + rental.RentedByAccountId);
                Console.WriteLine("lownMoverId: " + rental.LownMoverId);
                Console.WriteLine("unit: " + rental.HowLong);
                Console.WriteLine("Period: " + rental.Period);
                Console.WriteLine("Rented: " + rental.FromDate);
                Console.WriteLine("Returns: " + rental.ToDate);
            }
        }
    }
}
