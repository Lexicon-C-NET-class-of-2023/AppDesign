using Layers.Services;
using Layers.Views;
using Layers.Views.Accounts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Controllers
{
    public class AccountController
    {
        private AccountService accountService;
        public AccountController()
        {
            accountService = new AccountService();
        }


        public void Index()
        {
            char response = Menu.AccountMenu();

            (response switch
            {
                '1' => (Action)ViewAllAccounts,
                '2' => CreateNewAccount,
                '3' => ModifyAnAccount,
                '4' => DeleteAnAccount,
                _ => throw new ArgumentOutOfRangeException()
            })();
        }


        public void ViewAllAccounts()
        {
            var response = accountService.GetAll();
            ShowAccounts.ShowAllAccounts(response);
        }


        public void CreateNewAccount() //equivalent to url
        {
            string response = AddAccount.NewAccount();

            string[] temp = response.Split(',');
            string firstName = temp[0];
            string lastName = temp[1];
            string city = temp[3];
            string zipCode = temp[4];
            string street = temp[5];
            string phoneNr = temp[6];
            string email = temp[7];

            int age = 0;
            try
            {
                age = int.Parse(temp[2]);
            }
            catch
            {

            }

            accountService.Add(firstName, lastName, age, city, zipCode, street, phoneNr, email);
        }

        public void ModifyAnAccount()
        {
            //accountService.MethodName();
        }

        public void DeleteAnAccount()
        {
            //accountService.MethodName();
        }
    }
}