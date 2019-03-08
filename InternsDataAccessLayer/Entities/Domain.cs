using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class Domain : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public ICollection<SubDomain> SubDomains { get; set; }
    }
}
