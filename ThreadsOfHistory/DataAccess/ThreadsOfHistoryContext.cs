using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
