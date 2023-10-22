using Layers.Controllers;


namespace Layers.Views
{
    public static class Menu
    {
        public static void MainMenu()
        {
            string[] alternatives = { "1. Accounts", "2. Rentals", "3. Lawnmovers" };
            char choice = GetUserInput("Main menu", alternatives);


            if (choice == '1')
            {
                AccountController myAccountController = new AccountController();
                myAccountController.Index();
            }

            if (choice == '2')
            {
                RentalController myRentalController = new RentalController();
                myRentalController.Index();
            }
            else
            {
                LawnmoverController myLawnmoverController = new LawnmoverController();
                myLawnmoverController.Index();

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
        public static char RentalMenu()
        {
            string[] alternatives = {
                "1. Show current rentals",
                "2. Register a new hire of lawnmover",
                "3. Modify registered hire",
                "4. Deregister hire"
            };

            return GetUserInput("\n\n\nRental Options", alternatives);
        }

        public static char ChooseAccountThatWichToRentMenu(string[] alternatives)
        {
            return GetUserInput("\n\n\nWhich account to register the hire to?", alternatives);
        }

        public static int ChooseLawnmoverToRentMenu(string[] alternatives)
        {
            return GetUserInputDblDigit("\n\n\nChoose available lawnmover", alternatives);
        }

        public static char ChooseLawnmoverPeriod()
        {
            string[] alternatives = {
                "1. Per day",
                "2. Per week",
            };

            return GetUserInput("\n\n\nChoose Period", alternatives);
        }

        public static char ChooseRentalToModifyMenu(string[] alternatives) => GetUserInput("\n\n\nUpdate Rental Options", alternatives);
        public static char ModifyRentalMenu()
        {
            string[] alternatives = {
                "1. Modify RentedByAccountId",
                "2. Modify lownMoverId",
                "3. Modify Period",
                "4. Modify FromDate",
                "5. Modify HowLong",
                "6. Modify toDate"
            };

            return GetUserInput("\n\n\nUpdate Account Options", alternatives);
        }

        public static char ChooseRentalToDeleteMenu(string[] alternatives)
        {
            return GetUserInput("\n\n\nChoose Rental to Deregister", alternatives);
        }




        //LAWNMOVERS
        public static char LawnmoverMenu()
        {
            string[] alternatives = {
                "1. Show Inventory",
                "2. Show Available lawnmovers",
                "3. Register a new lawnmover", //not done
                "4. Modify lawnmover in inventory", //not done
                "5. Remove lawnmover from inventory" //not done
            };

            return GetUserInput("\n\n\nLawnmover Options", alternatives);
        }

        public static int ChooseLawnmoverToModifyMenu(string[] alternatives) => GetUserInputDblDigit("\n\n\nUpdate Lawnmover Options", alternatives);

        public static char ModifyLawnmoverMenu()
        {
            string[] alternatives = {
                "1. Modify Available",
                "2. Modify Model",
                "3. Modify PricePerDay",
                "4. Modify PricePerWeek",
                "5. Modify DateOfRent",
                "6. Modify DateOfReturn"
            };

            return GetUserInput("\n\n\nUpdate Lawnmover Options", alternatives);
        }

        public static int ChooseLawnmoverToDeleteMenu(string[] alternatives)
        {
            return GetUserInputDblDigit("\n\n\nChoose Lawnmover to remove", alternatives);
        }





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

        public static int GetUserInputDblDigit(string header, string[] alternatives)
        {
            int result = -1;
            int[] condition = new int[alternatives.Length];

            Console.WriteLine($"{header}\n");

            for (int i = 0; i < alternatives.Length; i++) condition[i] = i + 1;

            while (!condition.Contains(result))
            {
                foreach (var item in alternatives) Console.WriteLine(item);

                string DblDigit = Console.ReadLine();

                try
                {
                    result = int.Parse(DblDigit);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}