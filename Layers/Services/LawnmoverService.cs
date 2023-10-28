using Layers.Models;
using Layers.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Services
{
    internal class LawnmoverService
    {

        private LawnmoverRepo lawnmoverRepo;
        public LawnmoverService()
        {
            lawnmoverRepo = new LawnmoverRepo();
        }


        // GET ALL
        public List<dynamic> GetAll() => lawnmoverRepo.ReadAll();


        // GET AVAILABLE
        public List<dynamic> GetAvailable() => lawnmoverRepo.ReadAvailable();


        //  EDIT
        public void Edit(Lawnmover.LanwmoverPetrol lawnmover, char keyToModify, string newValue) => lawnmoverRepo.Update(lawnmover, keyToModify, newValue);
        public void Edit(Lawnmover.LawnmoverElectric lawnmover, char keyToModify, string newValue) => lawnmoverRepo.Update(lawnmover, keyToModify, newValue);


        //  DELETE
        public void Remove(Lawnmover.LanwmoverPetrol lawnmover) => lawnmoverRepo.Delete(lawnmover);
        public void Remove(Lawnmover.LawnmoverElectric lawnmover) => lawnmoverRepo.Delete(lawnmover);


        //  CREATE
        public void Add(string model, int pricePerDay, int pricePerWeek, char type,  int difference)
        {

            // might change from type to emission/batteryeffect
            if (type == '1')
            {
                Lawnmover.LanwmoverPetrol lawnmover = new Lawnmover.LanwmoverPetrol()
                {
                    Model = model,
                    PricePerDay = pricePerDay,
                    PricePerWeek = pricePerWeek,
                    Type = "petrol",
                    Emission = difference
                };

                //int instead?----------------------------------------
                //lawnmover.Emission = "862 g/kWh";

                lawnmoverRepo.Create(lawnmover);
            }
            if (type == '2')
            {
                Lawnmover.LawnmoverElectric lawnmover = new Lawnmover.LawnmoverElectric()
                {
                    Model = model,
                    PricePerDay = pricePerDay,
                    PricePerWeek = pricePerWeek,
                    Type = "electric",
                    BatteryCapacity = difference
                };

                //int instead?----------------------------------------
                //lawnmover.BatteryEffect = "75,6 or 146 Wh";

                lawnmoverRepo.Create(lawnmover);
            }
        }
    }
}
