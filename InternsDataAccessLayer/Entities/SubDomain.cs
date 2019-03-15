using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class SubDomain : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Advertise> Advertises { get; set; }
        public ICollection<Qa> Qas { get; set; }
        public int DomainId { get; set; }
    }
}
