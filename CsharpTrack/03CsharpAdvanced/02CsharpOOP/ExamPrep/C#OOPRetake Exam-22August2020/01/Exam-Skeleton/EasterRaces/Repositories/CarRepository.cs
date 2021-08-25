using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }


        public ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models;
        }

        public void Add(ICar model)
        {
            if (this.models.Contains(model))
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.CarExists, model.Model));
            }
            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
