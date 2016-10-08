using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IRepository<T> : IDisposable where T : BaseModel
    {
        Task<T> GetAsync(long id);
        Task<List<T>> GetAsync();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
