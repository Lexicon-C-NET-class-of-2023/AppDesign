using Layers.Models;
using System.Security.Principal;
using System.Text.Json;

namespace Layers.Repositories
{


    internal class LawnmoverRepo
    {
        private string path;

        public LawnmoverRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\DataBase\\lawnmovers.json";
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


        public Lawnmover Create(Lawnmover lawnmover)
        {
            List<Lawnmover> lawnmovers = FileRead();
            int newId = lawnmovers.OrderBy(a => a.Id).Last().Id + 1;
            lawnmover.Id = newId;
            lawnmover.Available = true;
            //lawnmover.DateOfRent = dateOfRent;  //set from rental findOneByid
            //lawnmover.DateOfReturn = dateOfReturn;  //set from rental findOneByid

            lawnmovers.Add(lawnmover);
            FileMutations(lawnmovers);
            return lawnmover;
        }

        public List<Lawnmover> ReadAll() => FileRead();
        public List<Lawnmover> ReadAvailable()
        {
            //Fetching the List from the DB
            List<Lawnmover> lawnmovers = FileRead();
            List<Lawnmover> available = lawnmovers.Where(a => a.Available == true).ToList();

            return available;
        }

        public Lawnmover ReadOne(int id)
        {
            //Fetching the List from the DB
            List<Lawnmover> lawnmovers = FileRead();
            //Filtering by id
            Lawnmover lawnmover = lawnmovers.Where(a => a.Id == id).ToList()[0];
            return lawnmover;
        }






        public Lawnmover Update(Lawnmover lawnmover, char keyToModify, string newValue)

        {
            int price = 0;

            if (keyToModify == '1')
            {
                lawnmover.Available = Convert.ToBoolean(newValue);
            }
            else if (keyToModify == '3')
            {
                price = int.Parse(newValue);
                lawnmover.PricePerDay = price;
            }
            else if (keyToModify == '4')
            {
                price = int.Parse(newValue);
                lawnmover.PricePerWeek = price;
            }

            string key = keyToModify switch
            {
                '2' => lawnmover.Model = newValue,
                '5' => lawnmover.DateOfRent = newValue,
                '6' => lawnmover.DateOfReturn = newValue,
                _ => ""
            };

            List<Lawnmover> lawnmovers = FileRead();
            List<Lawnmover> newList = lawnmovers.Where(a => a.Id != lawnmover.Id).ToList();

            newList.Add(lawnmover);

            FileMutations(newList);
            return lawnmover;
        }






        public bool Delete(Lawnmover lawnmover)
        {
            List<Lawnmover> lawnmovers = FileRead();
            List<Lawnmover> newList = lawnmovers.Where(a => a.Id != lawnmover.Id).ToList();

            FileMutations(newList);
            return true;
        }

        public bool FileMutations(List<Lawnmover> lawnmovers)
        {
            List<Lawnmover> sortedLawnmoverList = lawnmovers.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize(sortedLawnmoverList);
            File.WriteAllText(path, value);
            return true;
        }

        public List<Lawnmover> FileRead()
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

            List<Lawnmover> lawnmovers = JsonSerializer.Deserialize<List<Lawnmover>>(values);
            return lawnmovers;
        }
    }
}
