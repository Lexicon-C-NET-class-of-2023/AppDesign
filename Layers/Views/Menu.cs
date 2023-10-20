using Layers.Controllers;


namespace Layers.Views
{
    public static class Menu
    {
        public static void MainMenu()
        {
            string[] alternatives = { "1. Accounts", "2. Rentals" };
            char choice = GetUserInput("Main menu", alternatives);


            if (choice == '1')
            {
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

        //ACCOUNTS
        public static char AccountMenu()
        {
            string[] alternatives = {
                "1. Show Accounts",
                "2. Create New Account",
                "3. Modify Account",
                "4. Delete Account"
            };

            return GetUserInput("\n\n\nAccount Options", alternatives);
        }

        public static char ChooseAccountToModifyMenu(string[] alternatives) => GetUserInput("\n\n\nUpdate Account Options", alternatives);
        public static char ChooseAccountToDeleteMenu(string[] alternatives) => GetUserInput("\n\n\nDelete Account Options", alternatives);
        public static char ModifyAccountMenu()
        {
            string[] alternatives = {
                "1. Modify Firstname",
                "2. Modify Lastname",
                "3. Modify Age",
                "4. Modify City",
                "5. Modify Zip code",
                "6. Modify Street",
                "7. Modify Phonenumber",
                "8. Modify Email",
            };

            return GetUserInput("\n\n\nUpdate Account Options", alternatives);
        }

        //RENTALS
        //New menues for rental and so on goes here


        //Dynamic method for numerical user-input that takes the header and alternatives as arguments and automatically creates a condition from the length of the alternatives for breaking the while-loop 
        public static char GetUserInput(string header, string[] alternatives)
        {
            char key = 'a';
            int[] condition = new int[alternatives.Length];

            Console.WriteLine($"{header}\n");

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