using Layers.Models;
using Layers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Services
{
    public class AccountService
    {
        private AccountRepo accountRepo;
        public AccountService() {
            accountRepo = new AccountRepo();
        }

        public void GetAll()
        {

        }

        public void Edit() { }

        public void Remove() { }

        public bool Add (string name, int age)
        {
            int ageRestriction = 18;
            DateTime startDate = DateTime.Now.AddDays(-5);

            if (age < ageRestriction) return false;
            Account account = new Account();
            account.Name = name;
            account.Age = age;
            account.Balance = DateTime.Now > startDate ? 200 : 0;
           
            accountRepo.Create(account);
            return true;
        }
    }
}
