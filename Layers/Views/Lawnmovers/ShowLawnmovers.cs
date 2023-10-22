using Layers.Models;

namespace Layers.Views.Lawnmovers
{
    internal class ShowLawnmovers
    {
        public static void ShowAllLawnmovers(List<Lawnmover> lawnmovers)
        {
            Console.WriteLine("\n\n\nAll Lawnmovers\n");
            foreach (var lawnmover in lawnmovers)
            {
                Console.WriteLine("Id: " + lawnmover.Id);
                Console.WriteLine("Id: " + lawnmover.Model);
                if (!lawnmover.Available)
                {
                    Console.WriteLine("Rented on: " + lawnmover.DateOfRent);
                    Console.WriteLine("Available from: " + lawnmover.DateOfReturn);
                }
                Console.WriteLine();
            }
        }

        public static void ShowAvailableLawnmovers(List<Lawnmover> lawnmovers)
        {
            Console.WriteLine("\n\n\nAvailable Lawnmovers");
            foreach (var lawnmover in lawnmovers)
            {
                Console.WriteLine("\nId: " + lawnmover.Id);
                Console.WriteLine("Model: " + lawnmover.Model);
                Console.WriteLine("Rented on: " + lawnmover.DateOfRent);
                Console.WriteLine("Available from: " + lawnmover.DateOfReturn);
            }
            Console.WriteLine();
        }
    }
}