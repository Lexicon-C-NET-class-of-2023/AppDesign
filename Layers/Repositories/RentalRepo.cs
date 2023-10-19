using System.Text.Json;

namespace Layers.Models
{
    public class RentalRepo
    {
       
        
            private string path;

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
                List<Rental> rentals= FileRead();
                int newId = rentals.OrderBy(a => a.Id).Last().Id + 1;
                rental.Id = newId;
                rentals.Add(rental);
                FileMutations(rentals);
                return rental;
            }

            public List<Rental> ReadAll() => FileRead();


            public Rental Update(Rental rental)
                
            {
                //edit one of the objects in the List in database (by Id)
                //FileMutations ()
                return rental;
            }


            public bool Delete(int id)
            {
                //delete one of the objects in the List in database (by Id) 
                //FileMutations ()
                return false;
            }


            public bool FileMutations(List<Rental> rentals
                )
            {
                string value = JsonSerializer.Serialize<List<Rental>>(rentals);
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
