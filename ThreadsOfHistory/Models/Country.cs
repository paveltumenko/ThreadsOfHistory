using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        public string Name { get; set; }
    }
}