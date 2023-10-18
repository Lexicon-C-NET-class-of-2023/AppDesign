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
        public AccountService()
        {
            accountRepo = new AccountRepo();
        }

        //OBS add validation to all methods!

        public void GetAll()

        {
            accountRepo.ReadAll();
            //get List of all objects in databases
        }

        public void Edit()
        {
            //edit one of the objects in the List in database (by Id)
        }

        public void Remove()
        {
            //delete one of the objects in the List in database (by Id)
        }

        public bool Add(string name, int age)
        {
            //creates one objects to the List in database 

            //int ageRestriction = 18;
            //DateTime startDate = DateTime.Now.AddDays(-5);

            //if (age < ageRestriction) return false;
            //Account account = new Account();
            //account.Name = name;
            //account.Age = age;
            //account.Balance = DateTime.Now > startDate ? 200 : 0;

            //accountRepo.Create(account);
            return true;
        }
    }
}
