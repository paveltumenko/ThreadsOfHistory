using System.Collections.Generic;
using Models;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ThreadsOfHistoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.ThreadsOfHistoryContext";
        }

        protected override void Seed(ThreadsOfHistoryContext context)
        {
            context.Events.AddOrUpdate(e => e.Name,
                new Event
                {
                    Name = "America has been discovered",
                    Description = "",
                    StartDate = DateTime.Parse("1492/01/01"),
                    EndDate = null,
                    Scale = Scale.World,
                    People = new List<Person>
                    {
                        new Person
                        {
                            FirstName = "Christopher",
                            LastName = "Columbus",
                            Born = DateTime.Parse("1451/10/31"),
                            Died = DateTime.Parse("1506/05/20")
                        }
                    }
                });
            context.SaveChanges();

            context.Countries.AddOrUpdate(c => c.Name, 
                new Country {Code = 380, Name = "Italy"},
                new Country {Code = 840, Name = "United States"});
            context.SaveChanges();
        }
    }
}
