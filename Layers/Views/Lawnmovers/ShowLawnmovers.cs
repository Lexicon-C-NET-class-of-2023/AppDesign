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
                if (!lawnmover.Available) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("Id: " + lawnmover.Id);
                if (!lawnmover.Available)
                {
                    Console.WriteLine("Rented on: " + lawnmover.DateOfRent);
                    Console.WriteLine("Available from: " + lawnmover.DateOfReturn);
                }
                Console.WriteLine("Model: " + lawnmover.Model);
                Console.WriteLine("Price per day: " + lawnmover.PricePerDay);
                Console.WriteLine("Price per week: " + lawnmover.PricePerWeek);
                Console.WriteLine("Type: " + lawnmover.Type);
                if (lawnmover is Lawnmover.LanwmoverPetrol) Console.WriteLine($"Emission {lawnmover.Emission} g/kWh");
                if (lawnmover is Lawnmover.LawnmoverElectric) Console.WriteLine($"Emission {lawnmover.BatteryCapacity} Wh");

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
                if (lawnmover is Lawnmover.LanwmoverPetrol) Console.WriteLine($"Emission {lawnmover.Emission} g/kWh");
                if (lawnmover is Lawnmover.LawnmoverElectric) Console.WriteLine($"Emission {lawnmover.BatteryCapacity} Wh");
                Console.WriteLine("Price per day: " + lawnmover.PricePerDay);
                Console.WriteLine("Price per week: " + lawnmover.PricePerWeek);
            }
            Console.WriteLine();
        }
    }
}