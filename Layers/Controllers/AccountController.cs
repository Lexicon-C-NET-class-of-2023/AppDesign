using Layers.Services;
using Layers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string name = temp[0];
            int age = 0;
            try
            {
                age = int.Parse(temp[1]);
            }
            catch
            {

            }
            accountService.Add(name, age);
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