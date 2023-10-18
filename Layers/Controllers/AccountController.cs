using Layers.Services;
using Layers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Menu.AppMenu();

            //char response = Menu.GetChoice();
            //switch (response)
            //{
            //    case '1':
            //        Set();
            //        break;
            //    //case '2':
            //    //    accountService.GetAll();
            //    //    break;
            //    //case '3':
            //    //    accountService.Remove();
            //    //    break;
            //    default:
            //        break;
            //}
        }

        public void Set() //equivalent to url
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

        public void ViewAll()
        {

        }
    }
}
