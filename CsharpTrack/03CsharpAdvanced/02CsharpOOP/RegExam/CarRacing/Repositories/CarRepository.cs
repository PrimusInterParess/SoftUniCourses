using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
   public class CarRepository:IRepository<ICar>
   {
       private readonly List<ICar> models;

       public CarRepository()   
       {
           this.models = new List<ICar>();
       }

        public IReadOnlyCollection<ICar> Models
        {
            get => this.models.AsReadOnly();
        }
        public void Add(ICar model)
        {
            if (model==null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(c => c.VIN == property);
        }
    }
}
