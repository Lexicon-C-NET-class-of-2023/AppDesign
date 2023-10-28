using Layers.Models;
using Layers.Services;
using Layers.Views;
using Layers.Views.Rentals;
using static Layers.Views.Menu;

namespace Layers.Controllers
{
    public class RentalController
    {
        private RentalService rentalService;
        private AccountService accountService;
        private LawnmoverService lawnmoverService;
        public RentalController()
        {
            rentalService = new RentalService();
            accountService = new AccountService();
            lawnmoverService = new LawnmoverService();
        }


        public void Index()
        {
            char response = Menu.Rental.Index();

            (response switch
            {
                '1' => (Action)ViewAllRentals,
                '2' => RegisterNewRental,
                '3' => ModifyAnRental,
                '4' => DeleteRental,
                _ => throw new ArgumentOutOfRangeException()
            })();
        }

        public void ViewAllRentals()
        {
            var response = rentalService.GetAll();
            ShowRentals.ShowAllRentals(response);
        }

        public void RegisterNewRental() //equivalent to url
        {
            List<dynamic> accounts = accountService.GetAll();
            List<dynamic> listOfAvailableLawnmovers = lawnmoverService.GetAvailable();


            //Accounts to choose from
            List<string> listOfAccountOptions = new List<string>();

            foreach (var a in accounts) listOfAccountOptions.Add($"{a.Id}. {a.FirstName}");
            string[] arrayOfAccountOptions = listOfAccountOptions.Select(i => i.ToString()).ToArray();
            char chosenAccount = Menu.Rental.ChooseAccountMenu(arrayOfAccountOptions);
            int accountId = chosenAccount - '0';

            //Get One by id
            var account = accounts.Where(f => f.Id == accountId).ToList()[0];

            //Available lawnmovers to choose from
            List<string> listOfLawnmoverOptions = new List<string>();
                             

            int i = 0;
            foreach (var b in listOfAvailableLawnmovers)
            {
                //have to use index here instead since available lawnmovers Id do not correspond directly with options 
                listOfLawnmoverOptions.Add($"{i + 1}. {b.Model}");
                i++;
            }
            string[] arrayOfLawnmoverOptions = listOfLawnmoverOptions.Select(i => i.ToString()).ToArray();
            int lawnmoverIndex = Menu.Rental.ChooseLawnmoverMenu(arrayOfLawnmoverOptions) - 1;

            int lawnmoverId = listOfAvailableLawnmovers[lawnmoverIndex].Id;


            //Get One by id might not belog here
            //Models.Lawnmover lawnmover = lawnmoverService.GetOne(lawnmoverId);




            //view to choose period to rent
            var period = Menu.Rental.ChoosePeriod();
            Console.WriteLine("Period" + period);

            //view to choose how long
            string howLong = AddRental.NewRental();


           if (period == '1')
            {

            }


                //account is Models.Account.AccountPrime
            



            int time = 0;
            try
            {
                time = int.Parse(howLong);
            }
            catch
            {

            }

            rentalService.Add(accountId, lawnmoverId, period, time);
        }

        public void ModifyAnRental()

        {
            List<Models.Rental> rentals = rentalService.GetAll();

            //Dynamically creates alternatives to chooose from in Menu.ChooseAccountToModifyMenu
            List<string> temp = new List<string>();
            foreach (var a in rentals) temp.Add($"{a.Id}. {a.LownMoverId}");            //!!! Not correct yet
            string[] array = temp.Select(i => i.ToString()).ToArray();
            char chosen = Menu.Rental.Modify.ChooseWhichMenu(array);
            int id = chosen - '0';

            //Get One by id
            var rental = rentalService.GetOne(id);

            //Menu choosing what to modify
            char keyToModify = Menu.Rental.Modify.ChoosePropertyMenu();

            //view that prompts for new values
            string newValue = Menu.Rental.Modify.NewValueMenu(keyToModify);

            rentalService.Edit(rental, keyToModify, newValue);
        }

        public void DeleteRental()
        {

            var rentals = rentalService.GetAll();
            List<dynamic> accounts = accountService.GetAll();


            //Dynamically creates alternatives to chooose from in Menu.ChooseAccountToModifyMenu

            List<string> temp = new List<string>();
            foreach (var a in rentals)
            {
                //var account = accountService.GetOne(a.RentedByAccountId);



                var account = accounts.Where(f => f.Id == a.RentedByAccountId).ToList()[0];


                temp.Add($"{a.Id}. Hired by: {account.FirstName} {account.LastName}");
            }

            string[] array = temp.Select(i => i.ToString()).ToArray();
            char chosen = Menu.Rental.ChooseWhichToDeleteMenu(array);
            int id = chosen - '0';

            //Get One by id
            var rental = rentalService.GetOne(id);

            rentalService.Remove(rental);
        }
    }
}
