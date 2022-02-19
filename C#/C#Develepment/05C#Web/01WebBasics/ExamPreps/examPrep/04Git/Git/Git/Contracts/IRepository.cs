using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    internal interface IRepository
    {
        void Add<T>(T entity) where T : class;

        int SaveChanges();

        IQueryable<T> All<T>() where T : class;
    }
}
