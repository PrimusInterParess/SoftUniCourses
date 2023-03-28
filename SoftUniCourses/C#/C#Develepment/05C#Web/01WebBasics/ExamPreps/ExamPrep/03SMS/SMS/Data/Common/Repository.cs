

namespace SMS.Data.Common
{


    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Data;
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(SMSDbContext context)
        {
            dbContext = context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }
    }
}
