using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class Domain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public User User { get; set; }
        public int SubDomainId { get; set; }
        public ICollection<SubDomain> SubDomains { get; set; }
        public ICollection<Advertisment> Advertisments { get; set; }
    }
}
