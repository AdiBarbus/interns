using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
    }
}