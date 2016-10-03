using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ThreadsOfHistoryContext _context;

        public EventRepository()
        {
            _context = new ThreadsOfHistoryContext();
        }

        public Task<Event> GetAsync(long id)
        {
            return _context.Events.FindAsync(id);
        }

        public Task<List<Event>> GetAsync()
        {
            return _context.Events.ToListAsync();
        }

        public void Add(Event entity)
        {
            _context.Events.Add(entity);
        }

        public void Update(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(Event entity)
        {
            _context.Events.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
