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
            List<Account> accounts = FileRead();
            int newId = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Id = newId;
            accounts.Add(account);
            FileMutations(accounts);
            return account;
        }

        public List<Account> ReadAll() => FileRead();


        public Account Update(Account account)
        {
            //edit one of the objects in the List in database (by Id)
            //FileMutations ()
            return account;
        }


        public bool Delete(int id)
        {
            //delete one of the objects in the List in database (by Id) 
            //FileMutations ()
            return false;
        }


        public bool FileMutations(List<Account> accounts)
        {
            string value = JsonSerializer.Serialize<List<Account>>(accounts);
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
