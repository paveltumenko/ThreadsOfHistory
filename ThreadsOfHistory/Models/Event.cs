using System;
using System.Collections.Generic;

namespace Models
{
    public class Event : BaseModel
    {
        public Scale Scale { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
