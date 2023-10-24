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
            if (choice == '3')
            {
                LawnmoverController myLawnmoverController = new LawnmoverController();
                myLawnmoverController.Index();
            }
            else return;
        }



        public static class Account
        {
            public static char Index()
            {
                string[] alternatives = {
                    "1. Show Accounts",
                    "2. Create New Account",
                    "3. Modify Account",
                    "4. Delete Account"
                };

                return GetUserInput("\n\n\nAccount Options", alternatives);
            }

            public static class Modify
            {
                public static char ChooseWhichMenu(string[] alternatives) => GetUserInput("\n\n\nUpdate Account Options", alternatives);
                public static char ChoosePropertyMenu()
                {
                    string[] alternatives = {
                        "1. Modify Firstname",
                        "2. Modify Lastname",
                        "3. Modify Age",
                        "4. Modify City",
                        "5. Modify Zip code",
                        "6. Modify Street",
                        "7. Modify Phonenumber",
                        "8. Modify Email"
                    };

                    return GetUserInput("\n\n\nUpdate Account Options", alternatives);
                }

                public static string NewValueMenu(char property)
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

                    Console.WriteLine($"\n\nPlease enter new value for {key}");
                    return Console.ReadLine();
                }
            }

            public static char ChooseWhichToDeleteMenu(string[] alternatives) => GetUserInput("\n\n\nDelete Account Options", alternatives);
        }



        public static class Rental
        {
            public static char Index()
            {
                string[] alternatives = {
                    "1. Show current rentals",
                    "2. Register a new hire of lawnmover",
                    "3. Modify registered hire",
                    "4. Deregister hire"
                };

                return GetUserInput("\n\n\nRental Options", alternatives);
            }

            public static char ChooseAccountMenu(string[] alternatives) => GetUserInput("\n\n\nWhich account to register the hire to?", alternatives);
            public static int ChooseLawnmoverMenu(string[] alternatives) => GetUserInputDblDigit("\n\n\nChoose available lawnmover", alternatives);
            public static char ChoosePeriod()
            {
                string[] alternatives = {
                    "1. Per day",
                    "2. Per week",
                };

                return GetUserInput("\n\n\nChoose Period", alternatives);
            }


            public static class Modify
            {
                public static char ChooseWhichMenu(string[] alternatives) => GetUserInput("\n\n\nUpdate Rental Options", alternatives);
                public static char ChoosePropertyMenu()
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

                public static string NewValueMenu(char property)
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

                    Console.WriteLine($"\n\nPlease enter new value for {key}");
                    return Console.ReadLine();
                }
            }

            public static char ChooseWhichToDeleteMenu(string[] alternatives) => GetUserInput("\n\n\nChoose Rental to Deregister", alternatives);
        }



        public static class Lawnmover
        {
            public static char Index()
            {
                string[] alternatives = {
                    "1. Show Inventory",
                    "2. Show Available lawnmovers",
                    "3. Register a new lawnmover",
                    "4. Modify lawnmover in inventory",
                    "5. Remove lawnmover from inventory"
                };

                return GetUserInput("\n\n\nLawnmover Options", alternatives);
            }

            public static class Modify
            {
                public static int ChooseWhichMenu(string[] alternatives) => GetUserInputDblDigit("\n\n\nUpdate Lawnmover Options", alternatives);

                public static char ChoosePropertyMenu()
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

                public static string NewValueMenu(char property)
                {
                    string key = property switch
                    {
                        '1' => "Available",
                        '2' => "Model",
                        '3' => "PricePerDay",
                        '4' => "PricePerWeek",
                        '5' => "DateOfRent",
                        '6' => "DateOfReturn",
                        _ => ""
                    };

                    Console.WriteLine($"\n\nPlease enter new value for {key}");
                    return Console.ReadLine();
                }
            }

            public static int ChooseWhichToDeleteMenu(string[] alternatives) => GetUserInputDblDigit("\n\n\nChoose Lawnmover to remove", alternatives);
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