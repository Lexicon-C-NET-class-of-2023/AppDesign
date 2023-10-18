using Layers.Controllers;


namespace Layers.Views
{
    public static class Menu
    {
        public static void AppMenu()
        {
            string[] alternatives = { "Press 1 for Accounts", "Press 2 for Rentals" };
            char choice = GetUserInput(alternatives);


            if (choice == '1')
            {
                Console.WriteLine("You have chosen Create Account\n");
                AccountController myAccountController = new AccountController();
                myAccountController.Index();
            }
            else
            {
                Console.WriteLine("You have chosen to Rent\n");
                //RentController myRentController = new RentController();
                //myRentController.Index();
            }
        }




        public static char GetUserInput(string[] alternatives)
        {
            char key = 'a';
            int[] condition = new int[alternatives.Length];

            for (int i = 0; i < alternatives.Length; i++) condition[i] = i + 1;

            while (!condition.Contains(key - '0'))
            {
                foreach (var item in alternatives) Console.WriteLine(item);
                key = Console.ReadKey().KeyChar;
            }
            return key;
        }
    }
}