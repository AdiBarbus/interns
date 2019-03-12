using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class SubDomain : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Advertise> Advertises { get; set; }
        public ICollection<QA> QAs { get; set; }
        public int DomainId { get; set; }
    }
}
