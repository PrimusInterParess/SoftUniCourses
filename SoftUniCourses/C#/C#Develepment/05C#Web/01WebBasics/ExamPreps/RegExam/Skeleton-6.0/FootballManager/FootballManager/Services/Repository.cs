namespace FootballManager.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Repository:IRepository
    {
        private readonly DbContext dbContext;

        public Repository(FootballManagerDbContext context)
        {
            this.dbContext = context;
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

        public void Remove<T>(T entity) where T : class
        {
           DbSet<T>().Remove(entity);
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
