using Layers.Models;
using System.Text.Json;

namespace Layers.Repositories
{
    internal class RentalHistoryRepo
    {

        private string path;
        private LawnmoverRepo lawnmoverRepo = new LawnmoverRepo();

        public RentalHistoryRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\DataBase\\rentalHistory.json";

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public Rental Create(Rental rental)
        {
            int newId = 1;
            List<Rental> rentals = FileRead();
         
            if (rentals.Count > 0) newId = rentals.OrderBy(a => a.Id).Last().Id + 1;
            rental.Id = newId;

            rentals.Add(rental);
            FileMutations(rentals);

            return rental;
        }



        public List<Rental> ReadAll() => FileRead();



        public Rental ReadOne(int id)
        {
            //Fetching the List from the DB
            List<Rental> rentals = FileRead();
            //Filtering by id
            Rental rental = rentals.Where(a => a.Id == id).ToList()[0];
            return rental;
        }







        public bool FileMutations(List<Rental> rentals)
        {
            List<Rental> sortedRentalList = rentals.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize(sortedRentalList);
            File.WriteAllText(path, value);
            return true;
        }

        public List<Rental> FileRead()
        {
            string values = File.ReadAllText(path);
            //Console.WriteLine("The original JSON" + values);

            try
            {
                //TODO, NEEDS TO HANDLE EXCEPTIONS (RIGHT NOW IF PUT IN HERE IT WILL NOT BE ABLE TO RETURN A NEW LIST OF ACCOUNTS)
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Rental> rentals = JsonSerializer.Deserialize<List<Rental>>(values);
            return rentals;
        }
    }
}