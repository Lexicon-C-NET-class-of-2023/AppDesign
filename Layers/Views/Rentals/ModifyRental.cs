namespace Layers.Views.Rentals
{
    public class ModifyRental
    {
        public static string Property(char property)
        {
            string key = property switch
            {
                '1' => "RentedByAccountId",
                '2' => "lownMoverId",
                '3' => "Period (day/week)",
                '4' => "FromDate",
                '5' => "HowLong (int)",
                '6' => "toDate",
                _ => ""
            };

            Console.WriteLine($"Please enter new {key}");
            return Console.ReadLine();
        }
    }
}