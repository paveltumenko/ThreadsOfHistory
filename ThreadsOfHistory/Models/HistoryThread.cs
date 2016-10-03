using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HistoryThread : BaseModel
    {
        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
