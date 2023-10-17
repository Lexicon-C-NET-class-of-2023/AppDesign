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
        public AccountController() {
            accountService = new AccountService();
        }

        public void Index()
        {
            Menu.AppMenu();
            char response = Menu.GetChoice();
            switch(response)
            {
                case 'A':
                    Set();
                    break;
                default:
                    break;             
            }
        }

        public void Set()
        {
            string response = AddAccount.NewAccount();
            string[] temp = response.Split(',');
            string name = temp[0];
            int age = 0;
            try
            {
                age = int.Parse(temp[1]);
            }
            catch {
                
            }
            accountService.Add(name, age);

        }

        public void ViewAll()
        {

        }
    }
}
