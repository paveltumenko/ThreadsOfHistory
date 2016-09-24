using System;
using System.Collections.Generic;

namespace Models
{
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Scale Scale { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
