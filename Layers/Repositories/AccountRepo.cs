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


        public Account Create(Account account)
        {
            List<Account> accounts = FileRead();
            int newId = accounts.OrderBy(a => a.Id).Last().Id + 1;
            account.Id = newId;
            accounts.Add(account);
            FileMutations(accounts);
            return account;
        }

        public List<Account> ReadAll()
        {
            //get List of all objects in databases
            //FileRead() 
            return new List<Account> { new Account() };
        }
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


        public bool FileMutations (List<Account> accounts) 
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
