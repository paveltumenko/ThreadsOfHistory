using System.Collections.Generic;

namespace Models
{
    public class HistoryThread : BaseModel
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}
