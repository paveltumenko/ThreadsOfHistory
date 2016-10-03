using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event : BaseModel
    {
        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Scale Scale { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
