namespace FootballManager.Contracts
{
    using System;
    using System.Linq;

    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        int SaveChanges();

        IQueryable<T> All<T>() where T : class;

        void Remove<T>(T entity) where T : class;
    }
}
