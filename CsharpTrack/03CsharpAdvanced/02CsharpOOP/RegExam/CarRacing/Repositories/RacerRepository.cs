using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
   public class RacerRepository:IRepository<IRacer>
   {
       private readonly List<IRacer> models;

       public RacerRepository()
       {
           this.models = new List<IRacer>();
       }

        public IReadOnlyCollection<IRacer> Models
        {
            get => this.models.AsReadOnly();
        }
        public void Add(IRacer model)
        {
            if (model==null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(r => r.Username == property);
        }
    }
}
