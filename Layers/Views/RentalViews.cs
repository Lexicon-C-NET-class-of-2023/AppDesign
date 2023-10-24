﻿using Layers.Controllers;


namespace Layers.Views
{
    public static class RentalViews
    {
        public static void MainRentalViews()
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

            }
        }


        public static char AccountRentalViews()
        {
            string[] alternatives = {
                "1. Show Accounts",
                "2. Create New Account",
                "3. Modify Account",
                "4. Delete Account"
            };

            return GetUserInput("\n\n\nAccount Options", alternatives);
        }

        public static char ChooseAccountToModifyRentalViews(string[] alternatives) => GetUserInput("\n\n\nUpdate Account Options", alternatives);
        public static char ChooseAccountToDeleteRentalViews(string[] alternatives) => GetUserInput("\n\n\nDelete Account Options", alternatives);
        public static char ModifyAccountRentalViews()
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