using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;

namespace InternsDataAccessLayer.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string City { get; set; }
        public string County { get; set; }
        [Required]
        public string Street { get; set; }
        public int Number { get; set; }
        public int Zip { get; set; }
    }
}
