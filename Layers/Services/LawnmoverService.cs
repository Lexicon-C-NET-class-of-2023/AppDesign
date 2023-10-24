using Layers.Models;
using Layers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public List<Lawnmover> GetAll() => lawnmoverRepo.ReadAll();
        public List<Lawnmover> GetAvailable() => lawnmoverRepo.ReadAvailable();
        


        public Lawnmover GetOne(int id) => lawnmoverRepo.ReadOne(id);
        public void Edit(Lawnmover lawnmover, char keyToModify, string newValue) => lawnmoverRepo.Update(lawnmover, keyToModify, newValue);
        public void Remove(Lawnmover lawnmover) => lawnmoverRepo.Delete(lawnmover);


        public void Add(string model, int pricePerDay, int pricePerWeek)
        {
            Lawnmover lawnmover = new Lawnmover();
            lawnmover.Model = model;
            lawnmover.PricePerDay = pricePerDay;
            lawnmover.PricePerWeek = pricePerWeek;

            lawnmoverRepo.Create(lawnmover);
        }









    }
}
