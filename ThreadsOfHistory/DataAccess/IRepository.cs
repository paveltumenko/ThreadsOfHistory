using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IRepository<T> : IDisposable where T : BaseModel
    {
        Task<Event> GetAsync(decimal id);
        Task<List<Event>> GetAsync();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
