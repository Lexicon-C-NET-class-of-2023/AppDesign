using Layers.Models;


namespace Layers.Views.Rentals
{
    public class ShowRentals
    {
        public static void ShowAllRentals(List<Rental> rentals)
        {
            Console.WriteLine("\n\n\nRegistered Hires\n");
            foreach (var rental in rentals)
            {
                Console.WriteLine("Id: " + rental.Id);
                Console.WriteLine("RentedByAccountId: " + rental.RentedByAccountId);
                Console.WriteLine("lownMoverId: " + rental.LownMoverId);
                Console.WriteLine("Period: " + rental.Period);
                Console.WriteLine("Rented: " + rental.FromDate);
                Console.WriteLine("Returns: " + rental.ToDate);
            }
        }
    }
}