using Layers.Services;
using Layers.Views;
using Layers.Views.Accounts;

namespace Layers.Controllers
{
    internal class AccountsController
    {
        private AccountService accountService;

        public AccountsController()
        {
            accountService = new AccountService();
        }


        public void Index()
        {
            char response = Menu.Account.Index();

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
            string type = temp[8];

            int age = 0;
            try
            {
                age = int.Parse(temp[2]);
            }
            catch
            {

            }

            accountService.Add(firstName, lastName, age, city, zipCode, street, phoneNr, email, type);
        }

        public void ModifyAnAccount()
        {
            List<dynamic> accounts = accountService.GetAll();

            //Dynamically creates alternatives to chooose from in Menu.ChooseAccountToModifyMenu
            List<string> temp = new List<string>();
            foreach (var a in accounts) temp.Add($"{a.Id}. {a.FirstName}");
            string[] array = temp.Select(i => i.ToString()).ToArray();
            char chosen = Menu.Account.Modify.ChooseWhichMenu(array);
            int id = chosen - '0';

            //Get One by id
            var account = accounts.Where(f => f.Id == id).ToList()[0];

            //Menu choosing what to modify
            char keyToModify = Menu.Account.Modify.ChoosePropertyMenu();

            //view that prompts for new values
            string newValue = Menu.Account.Modify.NewValueMenu(keyToModify);

            accountService.Edit(account, keyToModify, newValue);
        }

        public void DeleteAnAccount()
        {
            var accounts = accountService.GetAll();

            //Dynamically creates alternatives to chooose from in Menu.ChooseAccountToModifyMenu
            List<string> temp = new List<string>();
            foreach (var a in accounts) temp.Add($"{a.Id}. {a.FirstName}");
            string[] array = temp.Select(i => i.ToString()).ToArray();
            char chosen = Menu.Account.ChooseWhichToDeleteMenu(array);
            int id = chosen - '0';

            //Get One by id
            var account = accounts.Where(f => f.Id == id).ToList()[0];

            accountService.Remove(account);
        }
    }
}