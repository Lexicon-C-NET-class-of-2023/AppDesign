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

        public void Edit(Rental rental)
        {
            
        }

        public void Remove(int id)
        {
            
        }

        public bool Add(string model, bool available, int pricePerDay, int pricePerWeek, DateTime dateOfRent, DateTime dateOfReturn)
        {
         

            return true;  
    }
}
