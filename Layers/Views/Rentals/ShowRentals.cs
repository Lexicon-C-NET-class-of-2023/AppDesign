using Layers.Models;


namespace Layers.Views.Rentals
{
    public class ShowRentals
    {
        public static void ShowAllRentals(List<Rental> rentals)
        {
            Console.WriteLine(rentals.Count() > 0 ? "\n\n\nRegistered Hires\n" : "\n\n\nThere are no Registered Hires\n");
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