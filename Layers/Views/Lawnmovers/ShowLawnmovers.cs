using Layers.Models;

namespace Layers.Views.Lawnmovers
{
    internal class ShowLawnmovers
    {
        public static void ShowAllLawnmovers(List<dynamic> lawnmovers)
        {
            Console.WriteLine("\n\n\nAll Lawnmovers\n");
            foreach (var lawnmover in lawnmovers)
            {
                Console.WriteLine("Id: " + lawnmover.Id);
                Console.WriteLine("Model: " + lawnmover.Model);
                Console.WriteLine("Type: " + lawnmover.Type);
                Console.WriteLine("Price per day: " + lawnmover.PricePerDay);
                Console.WriteLine("Price per week: " + lawnmover.PricePerWeek);
                if (!lawnmover.Available)
                {
                    Console.WriteLine("Rented on: " + lawnmover.DateOfRent);
                    Console.WriteLine("Available from: " + lawnmover.DateOfReturn);
                }
                Console.WriteLine();
            }
        }

        public static void ShowAvailableLawnmovers(List<dynamic> lawnmovers)
        {
            Console.WriteLine("\n\n\nAvailable Lawnmovers");
            foreach (var lawnmover in lawnmovers)
            {
                Console.WriteLine("\nId: " + lawnmover.Id);
                Console.WriteLine("Model: " + lawnmover.Model);
                Console.WriteLine("Type: " + lawnmover.Type);
                Console.WriteLine("Price per day: " + lawnmover.PricePerDay);
                Console.WriteLine("Price per week: " + lawnmover.PricePerWeek);
            }
            Console.WriteLine();
        }
    }
}