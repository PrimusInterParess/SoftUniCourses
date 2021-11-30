using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.Services
{
   public class TagsService :ITagService
   {
       private ApplicationDbContext dbContext;

        public TagsService(ApplicationDbContext dbContex)
        {
            this.dbContext = dbContex;
        }    

        public void Add(string name, int? importance)
        {
            var tag = new Tag()
            {
                Name = name,
                Improtance = importance
            };

            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();
        }

        public void BulgTagToProperies()
        {
            throw new NotImplementedException();
        }
    }
}
