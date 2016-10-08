using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public class PeopleRepository : IRepository<Person>
    {
        private readonly ThreadsOfHistoryContext _context;

        public PeopleRepository()
        {
            _context = new ThreadsOfHistoryContext();
        }

        public Task<Person> GetAsync(long id)
        {
            return _context.People.FindAsync(id);
        }

        public Task<List<Person>> GetAsync()
        {
            return _context.People.ToListAsync();
        }

        public void Add(Person entity)
        {
            _context.People.Add(entity);
        }

        public void Update(Person entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(Person entity)
        {
            _context.People.Remove(entity);
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
