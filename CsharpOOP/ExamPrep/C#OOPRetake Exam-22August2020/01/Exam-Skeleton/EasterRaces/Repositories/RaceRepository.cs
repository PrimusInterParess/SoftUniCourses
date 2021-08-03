using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
       // private readonly List<IRace> models;

       
        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
          return this.models.Remove(model);
        }
    }
}
