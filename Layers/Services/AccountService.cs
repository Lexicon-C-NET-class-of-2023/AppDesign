using Layers.Models;
using Layers.Repositories;


namespace Layers.Services
{
    public class AccountService
    {
        private AccountRepo accountRepo;
        public AccountService()
        {
            accountRepo = new AccountRepo();
        }


        //OBS add validation to methods belong here!
        public List<Account> GetAll() => accountRepo.ReadAll();
        public Account GetOne(int id) => accountRepo.ReadOne(id);
        public void Edit(Account account, char keyToModify, string newValue) => accountRepo.Update(account, keyToModify, newValue);
        public void Remove(Account account) => accountRepo.Delete(account);
        public void Add(string firstName, string lastName, int age, string city, string zipCode, string street, string phoneNr, string email)
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
        }
    }
}