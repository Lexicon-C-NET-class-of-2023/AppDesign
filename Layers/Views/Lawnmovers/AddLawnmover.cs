namespace Layers.Views.Lawnmovers
{
    internal class AddLawnmover
    {
        public static string NewLawnmover()
        {
            string model;
            string pricePerDay;
            string pricePerWeek;
            bool invalid = true;

            do
            {
                Console.WriteLine("\n\nPlease enter model:");
                model = Console.ReadLine();

                Console.WriteLine("\nPlease enter price per day:");
                pricePerDay = Console.ReadLine();

                Console.WriteLine("\nPlease enter price per week:");
                pricePerWeek = Console.ReadLine();

                if (model != "" || pricePerDay != "" || pricePerWeek != "") invalid = false;
            } while (invalid);

            return $"{model},{pricePerDay},{pricePerWeek}";
        }
    }
}