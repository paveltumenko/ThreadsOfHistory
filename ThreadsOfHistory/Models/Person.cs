using System;
using System.Collections.Generic;

namespace Models
{
    public class Person : BaseModel
    {
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
