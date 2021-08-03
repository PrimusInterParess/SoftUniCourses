using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : Repository<ICar>
    {


        public ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
