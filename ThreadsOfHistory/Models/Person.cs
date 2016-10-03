using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Person : BaseModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Born { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Died { get; set; }

        public string FullName => $"{LastName}, {MiddleName} {FirstName}";

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
