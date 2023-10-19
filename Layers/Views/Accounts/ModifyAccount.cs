namespace Layers.Views.Accounts
{
    public class ModifyAccount
    {
        public static string Property(char property)
        {
            string key = property switch
            {
                '1' => "Firstname",
                '2' => "Lastname",
                '3' => "Age",
                '4' => "City",
                '5' => "Zip code",
                '6' => "Street",
                '7' => "Phone number",
                '8' => "Email",
                _ => ""
            };

            Console.WriteLine($"Please enter new {key}:");
            return Console.ReadLine();
        }
    }
}