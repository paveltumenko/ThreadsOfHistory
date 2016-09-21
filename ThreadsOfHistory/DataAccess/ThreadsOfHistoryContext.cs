using System.Data.Entity;
using Models;

namespace DataAccess
{
    public class ThreadsOfHistoryContext : DbContext
    {
        public ThreadsOfHistoryContext() : base("")
        {
        }

        public DbSet<HistoryThread> HistoryThreads { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
