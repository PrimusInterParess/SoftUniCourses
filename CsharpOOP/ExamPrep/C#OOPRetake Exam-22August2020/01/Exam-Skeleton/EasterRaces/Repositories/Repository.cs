using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories
{
   public abstract class Repository<IEntity>
   {
       
       protected Repository()
       {
           this.models = new List<IEntity>();
       }

       protected List<IEntity> models;
   }
}
