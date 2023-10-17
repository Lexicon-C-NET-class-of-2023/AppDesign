using System;

namespace YourApplicationNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayMainMenu();
                char choice = GetMainMenuChoice();

                switch (choice)
                {
                    case 'A':
                        CreateNewAccount();
                        break;
                    case 'E':
                        EditAccount();
                        break;
                    case 'R':
                        RemoveAccount();
                        break;
                    case 'L':
                        ListAllAccounts();
                        break;
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("A - Add New Account");
            Console.WriteLine("E - Edit Account");
            Console.WriteLine("R - Remove Account");
            Console.WriteLine("L - List All Accounts");
            Console.WriteLine("Q - Quit");
        }

        private static char GetMainMenuChoice()
        {
            char choice;
            do
            {
                Console.Write("Enter your choice: ");
                choice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (choice != 'A' && choice != 'E' && choice != 'R' && choice != 'L' && choice != 'Q');
            return choice;
        }

        private static void CreateNewAccount()
        {
            string accountData = Views.AddAccount.NewAccount();
            string[] accountDetails = accountData.Split(',');
            if (accountDetails.Length != 2)
            {
                Console.WriteLine("Invalid input. Please enter a name and age separated by a comma.");
                return;
            }

            string name = accountDetails[0];
            if (!int.TryParse(accountDetails[1], out int age))
            {
                Console.WriteLine("Invalid age. Please enter a valid age.");
                return;
            }

            if (Services.AccountService.Add(name, age))
            {
                Console.WriteLine("Account added successfully.");
            }
            else
            {
                Console.WriteLine("Age is below the restriction. Account not created.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void EditAccount()
        {
            // Implement edit account logic here.
        }

        private static void RemoveAccount()
        {
            // Implement remove account logic here.
        }

        private static void ListAllAccounts()
        {
            var accounts = Services.AccountService.GetAll();
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
            }
            else
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine($"ID: {account.Id}, Name: {account.FirstName}, Age: {account.Age}, Balance: {account.Balance}");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
