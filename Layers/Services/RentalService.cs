using Layers.Repositories;
using System.IO;
using System.Reflection.Emit;
using System.Security.Principal;

namespace Layers.Models
{
    public class RentalService
    {
        private RentalRepo rentalRepo;
        public RentalService()
        {
            rentalRepo = new RentalRepo();
        }

        public List<Rental> GetAll() => rentalRepo.ReadAll();
        public Rental GetOne(int id) => rentalRepo.ReadOne(id);    
        public void Edit(Rental rental, char keyToModify, string newValue) => rentalRepo.Update(rental, keyToModify, newValue);

        public void Remove(Rental rental) => rentalRepo.Delete(rental);


        public bool Add(int accountId, int lawnmoverId, char period, int time, decimal cost,bool useDiscount)
        {
            string chosen = period switch
            {
                '1' => "day",
                '2' => "week",
                _ => ""
            };

            Rental rental = new Rental();
            rental.HowLong = time;
            rental.RentedByAccountId = accountId;
            rental.LownMoverId = lawnmoverId;
            rental.Period = chosen;
            rental.Cost = cost;
            rental.DiscountUsed = useDiscount;

            rentalRepo.Create(rental);

            return true;
        }
    }
}
