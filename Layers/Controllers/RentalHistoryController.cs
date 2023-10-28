using Layers.Services;
using Layers.Views;
using Layers.Views.Rentals;

namespace Layers.Controllers
{
    public class RentalHistoryController
    {
        private RentalHistoryService rentalHistoryService;

        public RentalHistoryController()
        {
            rentalHistoryService = new RentalHistoryService();
        }


        public void Index()
        {
            char response = Menu.RentalHistory.Index();

            (response switch
            {
                '1' => (Action)ViewRentalHistory,
                _ => throw new ArgumentOutOfRangeException()
            })();
        }

        public void ViewRentalHistory()
        {
            var response = rentalHistoryService.GetAll();
            ShowRentals.ShowAllRentals(response);
        }
    }
}
