using Layers.Models;
using Layers.Repositories;

namespace Layers.Services
{
    internal class AccountService
    {

        private AccountRepo accountRepo;
        public AccountService()
        {
            accountRepo = new AccountRepo();
        }


        // GET ALL
        public List<dynamic> GetAll() => accountRepo.ReadAll();


        //  GET ONE
        public Account.AccountBasic GetOneBasic(int id) => accountRepo.ReadOneBasic(id);
        public Account.AccountPrime GetOnePrime(int id) => accountRepo.ReadOnePrime(id);


        //  EDIT
        public void Edit(Account.AccountBasic account, char keyToModify, string newValue) => accountRepo.Update(account, keyToModify, newValue);
        public void Edit(Account.AccountPrime account, char keyToModify, string newValue) => accountRepo.Update(account, keyToModify, newValue);


        //  DELETE
        public void Remove(Account.AccountBasic account) => accountRepo.Delete(account);
        public void Remove(Account.AccountPrime account) => accountRepo.Delete(account);


        //  CREATE
        public void Add(string firstName, string lastName, int age, string city, string zipCode, string street, string phoneNr, string email, string type)
        {
            if (type == "basic")
            {
                Account.AccountBasic account = new Account.AccountBasic();
                account.FirstName = firstName;
                account.Age = age;
                account.LastName = lastName;
                account.City = city;
                account.ZipCode = zipCode;
                account.Street = street;
                account.Phonenumber = phoneNr;
                account.Email = email;
                account.Type = type;

                accountRepo.Create(account);
            }

            if (type == "prime")
            {
                Account.AccountPrime account = new Account.AccountPrime();
                account.FirstName = firstName;
                account.Age = age;
                account.LastName = lastName;
                account.City = city;
                account.ZipCode = zipCode;
                account.Street = street;
                account.Phonenumber = phoneNr;
                account.Email = email;
                account.Type = type;

                accountRepo.Create(account);
            }
        }
    }
}