using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Models;

namespace DataAccess
{
    public class ThreadsOfHistoryContext : DbContext
    {
        public ThreadsOfHistoryContext() : base("ThreadsOfHistoryContext")
        {
        }

        public DbSet<HistoryThread> HistoryThreads { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new DateConvention());
        }
    }

    public class DateConvention : Convention
    {
        public DateConvention()
        {
            Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2").HasPrecision(3));

            Properties<DateTime>()
                .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
                .Any(a => a.DataType == DataType.Date))
                .Configure(c => c.HasColumnType("date"));
        }
    }
}
