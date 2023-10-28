using Layers.Repositories;
using System.Text.Json;
using static Layers.Views.Menu;

namespace Layers.Models
{
    public class RentalRepo
    {
        private string path;
        private LawnmoverRepo lawnmoverRepo = new LawnmoverRepo();
        private RentalHistoryRepo rentalHistoryRepo = new RentalHistoryRepo();

        public RentalRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\DataBase\\rentals.json";
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
            List<dynamic> lawnmovers = lawnmoverRepo.ReadAll();

            if (rentals.Count > 0) newId = rentals.OrderBy(a => a.Id).Last().Id + 1;
            rental.Id = newId;


            DateTime now = DateTime.Now;

            string date = now.ToString();

            rental.FromDate = date;
            rental.ToDate = rental.Period == "day" ? now.AddDays(rental.HowLong).ToString() : now.AddDays(rental.HowLong * 7).ToString();


            //Modify properties on the Lawnmover object
            var lawnmover = lawnmovers.Where(f => f.Id == rental.LownMoverId).ToList()[0];
            lawnmoverRepo.Update(lawnmover, '1', false.ToString());
            lawnmoverRepo.Update(lawnmover, '5', date);
            lawnmoverRepo.Update(lawnmover, '6', rental.Period == "day" ? now.AddDays(rental.HowLong).ToString() : now.AddDays(rental.HowLong * 7).ToString());





            // Add lawnmover rental cost to account.bonus






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

        public Rental Update(Rental rental, char keyToModify, string newValue)

        {
            DateTime now = DateTime.Now;
            int temp = 0;

            if (keyToModify == '1')
            {
                temp = int.Parse(newValue);
                rental.RentedByAccountId = temp;
            }
            else if (keyToModify == '2')
            {
                temp = int.Parse(newValue);
                rental.LownMoverId = temp;
            }
            else if (keyToModify == '3')
            {
                rental.Period = newValue;
                rental.ToDate = rental.Period == "day" ? now.AddDays(rental.HowLong).ToString() : now.AddDays(rental.HowLong * 7).ToString();
            }
            else if (keyToModify == '5')
            {
                temp = int.Parse(newValue);

                rental.HowLong = temp;
                rental.ToDate = rental.Period == "day" ? now.AddDays(rental.HowLong).ToString() : now.AddDays(rental.HowLong * 7).ToString();
            }

            string key = keyToModify switch
            {
                '3' => rental.Period = newValue,
                '4' => rental.FromDate = newValue,
                '6' => rental.ToDate = newValue,
                _ => ""
            };

            List<Rental> rentals = FileRead();
            List<Rental> newList = rentals.Where(a => a.Id != rental.Id).ToList();

            newList.Add(rental);

            FileMutations(newList);

            return rental;
        }


        public bool Delete(Rental rental)
        {
            List<Rental> rentals = FileRead();
            List<dynamic> lawnmovers = lawnmoverRepo.ReadAll();


            //Modify availibility on Lawnmover object
            var lawnmover = lawnmovers.Where(f => f.Id == rental.LownMoverId).ToList()[0];
            lawnmoverRepo.Update(lawnmover, '1', true.ToString());
            lawnmoverRepo.Update(lawnmover, '5', "");
            lawnmoverRepo.Update(lawnmover, '6', "");

            //Save rental to history
            Rental rentalToSave = rentals.Where(a => a.Id == rental.Id).ToList()[0];
            rentalHistoryRepo.Create(rentalToSave);

            List<Rental> newList = rentals.Where(a => a.Id != rental.Id).ToList();

            FileMutations(newList);
            return true;
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