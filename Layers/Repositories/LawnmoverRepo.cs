using Layers.Models;
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


        //  CREATE
        public Lawnmover.LanwmoverPetrol Create(Lawnmover.LanwmoverPetrol lawnmover)
        {
            List<dynamic> lawnmovers = FileRead();

            int newId = lawnmovers.OrderBy(a => a.Id).Last().Id + 1;   //System.InvalidOperationException Sequence contains no elements
            lawnmover.Id = newId;
            lawnmover.Available = true;

            lawnmovers.Add(lawnmover);
            FileMutations(lawnmovers);
            return lawnmover;
        }
        public Lawnmover.LawnmoverElectric Create(Lawnmover.LawnmoverElectric lawnmover)
        {
            List<dynamic> lawnmovers = FileRead();
            int newId = lawnmovers.OrderBy(a => a.Id).Last().Id + 1;
            lawnmover.Id = newId;
            lawnmover.Available = true;

            lawnmovers.Add(lawnmover);
            FileMutations(lawnmovers);
            return lawnmover;
        }


        //  GET ALL
        public List<dynamic> ReadAll() => FileRead();

        //  GET AVAILABLE
        public List<dynamic> ReadAvailable()
        {
            //Fetching the List from the DB
            List<dynamic> lawnmovers = FileRead();
            List<dynamic> available = lawnmovers.Where(a => a.Available == true).ToList();

            return available;
        }

        //  GET ONE
        public Lawnmover.LanwmoverPetrol ReadOnePetrol(int id)
        {
            //Fetching the List from the DB
            List<dynamic> lawnmovers = FileRead();
            //Filtering by id
            Lawnmover.LanwmoverPetrol lawnmover = lawnmovers.Where(a => a.Id == id).ToList()[0];
            return lawnmover;
        }
        public Lawnmover.LawnmoverElectric ReadOneElectric(int id)
        {
            //Fetching the List from the DB
            List<dynamic> lawnmovers = FileRead();
            //Filtering by id
            Lawnmover.LawnmoverElectric lawnmover = lawnmovers.Where(a => a.Id == id).ToList()[0];
            return lawnmover;
        }




        //  UPDATE
        public Lawnmover.LanwmoverPetrol Update(Lawnmover.LanwmoverPetrol lawnmover, char keyToModify, string newValue)
        {
            int price = 0;

            if (keyToModify == '1')
            {
                lawnmover.Available = Convert.ToBoolean(newValue); //try catch 
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

            List<dynamic> lawnmovers = FileRead();
            List<dynamic> newList = lawnmovers.Where(a => a.Id != lawnmover.Id).ToList();

            newList.Add(lawnmover);

            FileMutations(newList);
            return lawnmover;
        }
        public Lawnmover.LawnmoverElectric Update(Lawnmover.LawnmoverElectric lawnmover, char keyToModify, string newValue)
        {
            int price = 0;

            if (keyToModify == '1')
            {
                lawnmover.Available = Convert.ToBoolean(newValue); //try catch 
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

            List<dynamic> lawnmovers = FileRead();
            List<dynamic> newList = lawnmovers.Where(a => a.Id != lawnmover.Id).ToList();

            newList.Add(lawnmover);

            FileMutations(newList);
            return lawnmover;
        }

        //  DELETE
        public bool Delete(dynamic lawnmover)
        {
            List<dynamic> lawnmovers = FileRead();
            List<dynamic> newList = lawnmovers.Where(a => a.Id != lawnmover.Id).ToList();

            FileMutations(newList);
            return true;
        }




        public bool FileMutations(List<dynamic> lawnmovers)
        {
            List<dynamic> sortedLawnmoverList = lawnmovers.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize(sortedLawnmoverList);
            File.WriteAllText(path, value);
            return true;
        }

        public List<dynamic> FileRead()
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

            List<dynamic> listOfDynamicObjects = JsonSerializer.Deserialize<List<dynamic>>(values);
            List<dynamic> listOfLawnmoverTypes = new List<dynamic>();

            foreach (var item in listOfDynamicObjects)
            {
                var temporaryObject = JsonSerializer.Deserialize<Lawnmover.Temp>(item);

                if (temporaryObject.Type == "petrol")
                {
                    Lawnmover.LanwmoverPetrol petrolLawnmover = new Lawnmover.LanwmoverPetrol()
                    {
                        Id = temporaryObject.Id,
                        Model = temporaryObject.Model,
                        Available = temporaryObject.Available,
                        PricePerDay = temporaryObject.PricePerDay,
                        PricePerWeek = temporaryObject.PricePerWeek,
                        DateOfRent = temporaryObject.DateOfRent,
                        DateOfReturn = temporaryObject.DateOfReturn,
                        Type = temporaryObject.Type,
                        Emission = temporaryObject.Emission,
                    };

                    listOfLawnmoverTypes.Add(petrolLawnmover);
                }

                if (temporaryObject.Type == "electric")
                {
                    Lawnmover.LawnmoverElectric electricLawnmover = new Lawnmover.LawnmoverElectric()
                    {
                        Id = temporaryObject.Id,
                        Model = temporaryObject.Model,
                        Available = temporaryObject.Available,
                        PricePerDay = temporaryObject.PricePerDay,
                        PricePerWeek = temporaryObject.PricePerWeek,
                        DateOfRent = temporaryObject.DateOfRent,
                        DateOfReturn = temporaryObject.DateOfReturn,
                        Type = temporaryObject.Type,
                        BatteryEffect = temporaryObject.BatteryEffect,
                    };

                    listOfLawnmoverTypes.Add(electricLawnmover);
                }
            }

            return listOfLawnmoverTypes;
        }
    }
}
