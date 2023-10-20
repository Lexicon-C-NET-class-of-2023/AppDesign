using Layers.Models;
using System.Text.Json;


namespace Layers.Repositories
{
    public class AccountRepo
    {
        private string path;

        public AccountRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\DataBase\\account.json";
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Account Create(Account account)
        {
            //Fetching the List from the DB
            List<Account> accounts = FileRead();
            //Appending data
            account.Id = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Registered = DateTime.Now.ToString();
            //Adding the new account to accounts
            accounts.Add(account);
            //Saving the new List to DB
            FileMutations(accounts);
            return account;
        }

        public List<Account> ReadAll() => FileRead();

        public Account ReadOne(int id)
        {
            //Fetching the List from the DB
            List<Account> accounts = FileRead();
            //Filtering by id
            Account account = accounts.Where(a => a.Id == id).ToList()[0];
            return account;
        }

        public Account Update(Account account, char keyToModify, string newValue)
        {
            int age = 0;

            if (keyToModify == '3')
            {
                age = int.Parse(newValue);
                account.Age = age; //didn't work in the switch statement for some reason
            }

            string key = keyToModify switch
            {
                '1' => account.FirstName = newValue,
                '2' => account.LastName = newValue,
                '4' => account.City = newValue,
                '5' => account.ZipCode = newValue,
                '6' => account.Street = newValue,
                '7' => account.Phonenumber = newValue,
                '8' => account.Email = newValue,
                _ => ""
            };

            List<Account> accounts = FileRead();
            List<Account> newList = accounts.Where(a => a.Id != account.Id).ToList();

            newList.Add(account);

            FileMutations(newList);
            return account;
        }

        public bool Delete(Account account)
        {
            List<Account> accounts = FileRead();
            List<Account> newList = accounts.Where(a => a.Id != account.Id).ToList();

            FileMutations(newList);
            return true;
        }


        public bool FileMutations(List<Account> accounts)
        {
            List<Account> sortedAccountList = accounts.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize<List<Account>>(sortedAccountList);
            File.WriteAllText(path, value);
            return true;
        }

        public List<Account> FileRead()
        {
            string values = File.ReadAllText(path);
            //Console.WriteLine("The original JSON" + values);

            try
            {
                //TODO, NEEDS TO HANDLE EXCEPTIONS (RIGHT NOW IF PUT IN HERE IT WILL NOT BE ABLE TO RETURN A NEW LIST OF ACCOUNTS)
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(values);
            return accounts;
        }
    }
}