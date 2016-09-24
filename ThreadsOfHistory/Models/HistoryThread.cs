using System.Collections.Generic;

namespace Models
{
    public class HistoryThread : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
