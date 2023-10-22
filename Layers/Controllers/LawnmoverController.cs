using Layers.Services;
using Layers.Views;
using Layers.Views.Accounts;
using Layers.Views.Lawnmovers;

namespace Layers.Controllers
{
    internal class LawnmoverController
    {
        private LawnmoverService lawnmoverService;

        public LawnmoverController()
        {
            lawnmoverService = new LawnmoverService();
        }


        public void Index()
        {
            char response = Menu.LawnmoverMenu();

            (response switch
            {
                '1' => (Action)ViewAllLawnMovers,
                '2' => ViewAvailableLawnMovers,
                '3' => CreateNewLawnmover,
                '4' => ModifyALawnmover,
                '5' => DeleteALawnmover,
                _ => throw new ArgumentOutOfRangeException()
            })();
        }


        public void ViewAllLawnMovers()
        {
            var response = lawnmoverService.GetAll();
            ShowLawnmovers.ShowAllLawnmovers(response);
        }

        public void ViewAvailableLawnMovers()
        {
            var response = lawnmoverService.GetAvailable();
            ShowLawnmovers.ShowAvailableLawnmovers(response);
        }



        public void CreateNewLawnmover()
        {
            string response = AddLawnmover.NewLawnmover();

            string[] temp = response.Split(',');

            string model = temp[0];
            int pricePerDay = 0;
            int pricePerWeek = 0;

            try
            {
                pricePerDay = int.Parse(temp[1]);
                pricePerWeek = int.Parse(temp[2]);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            lawnmoverService.Add(model, pricePerDay, pricePerWeek);
        }

        public void ModifyALawnmover()
        {
            List<Models.Lawnmover> lawnmovers = lawnmoverService.GetAll();

            //Dynamically creates alternatives to chooose from in Menu.ChooseAccountToModifyMenu
            List<string> temp = new List<string>();
            foreach (var a in lawnmovers) temp.Add($"{a.Id}. {a.Model}");
            string[] array = temp.Select(i => i.ToString()).ToArray();
            int id = Menu.ChooseLawnmoverToModifyMenu(array);

            //Get One by id
            var lawnmover = lawnmoverService.GetOne(id);

            //Menu choosing what to modify
            char keyToModify = Menu.ModifyLawnmoverMenu();

            //view that prompts for new values
            string newValue = ModifyLawnmover.Property(keyToModify);

            lawnmoverService.Edit(lawnmover, keyToModify, newValue);
        }

        public void DeleteALawnmover()
        {
            var lawnmovers = lawnmoverService.GetAll();

            //Dynamically creates alternatives to chooose from in Menu.ChooseLawnmoverToDeleteMenu
            List<string> temp = new List<string>();
            foreach (var a in lawnmovers) temp.Add($"{a.Id}. {a.Model}");
            string[] array = temp.Select(i => i.ToString()).ToArray();
            int id = Menu.ChooseLawnmoverToDeleteMenu(array);

            //Get One by id
            var lawnmover = lawnmoverService.GetOne(id);

            lawnmoverService.Remove(lawnmover);
        }
    }
}
