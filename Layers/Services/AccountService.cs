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

        public List<Account> GetAll() => accountRepo.ReadAll();


        public void Edit()
        {
            //edit one of the objects in the List in database (by Id)
        }

        public void Remove()
        {
            //delete one of the objects in the List in database (by Id)
        }

        public bool Add(string firstName, string lastName, int age, string city, string zipCode, string street, string phoneNr, string email)
        {
            Account account = new Account();
            account.FirstName = firstName;
            account.Age = age;
            account.LastName = lastName;
            account.City = city;
            account.ZipCode = zipCode;
            account.Street = street;
            account.Phonenumber = phoneNr;
            account.Email = email;

            accountRepo.Create(account);
            return true;
        }
    }
}