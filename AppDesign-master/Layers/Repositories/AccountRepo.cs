using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Layers.Repositories
{
    public class AccountRepo
    {

        private string path = @"C:Users/tobiasengberg/Coding/Layers/Data/account_data.json";
        public AccountRepo() 
        { 

        }

        public List<Account> ReadAll()
        {
            return new List<Account> { new Account() };
        }

        public Account Create(Account account)
        {
            List<Account> accounts = FileRead();
            int newId = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Id = newId;
            accounts.Add(account);
            FileAction(accounts);
            return account;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Account Update(Account account)
        {
            return account;
        }

        public bool FileAction (List<Account> accounts) 
        {
            string value = JsonSerializer.Serialize<List<Account>>(accounts);
            File.WriteAllText(path, value);
            return true;
        }

        public List<Account> FileRead() 
        {
            string values = File.ReadAllText(path);
            List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(values);
            return accounts;
        }


    }
}
