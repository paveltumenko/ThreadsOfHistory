using System;
using System.Collections.Generic;
using System.Data.Entity;
using Models;

namespace DataAccess
{
    public class HistoryInitializer : DropCreateDatabaseIfModelChanges<ThreadsOfHistoryContext>
    {
        protected override void Seed(ThreadsOfHistoryContext context)
        {
            var events = new List<Event>
            {
                new Event
                {
                    Name = "America has been discovered",
                    Description = "",
                    StartDate = DateTime.Parse("1492"),
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
                }
            };

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var countries = new List<Country>
            {
                new Country { Code = 380, Name = "Italy" },
                new Country { Code = 840, Name = "United States" },
            };

            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
        }
    }
}
