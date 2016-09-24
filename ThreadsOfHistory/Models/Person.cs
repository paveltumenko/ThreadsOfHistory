using System;
using System.Collections.Generic;

namespace Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public DateTime? Died { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
