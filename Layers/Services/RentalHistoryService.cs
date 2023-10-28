using Layers.Models;
using Layers.Repositories;

namespace Layers.Services
{
    public class RentalHistoryService
    {
        
        private RentalHistoryRepo rentalHistoryRepo;
        public RentalHistoryService()
        {
            rentalHistoryRepo = new RentalHistoryRepo();
        }

        public List<Rental> GetAll() => rentalHistoryRepo.ReadAll();
    }
}