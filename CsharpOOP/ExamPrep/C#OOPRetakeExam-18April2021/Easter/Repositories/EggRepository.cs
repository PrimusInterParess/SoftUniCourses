using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)this.models;


        public void Add(IEgg model)
        {


            this.models.Add(model);

        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }

        public IEgg FindByName(string name)
        {

            return this.models.FirstOrDefault(e => e.Name == name);

        }
    }
}
