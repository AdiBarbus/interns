using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class Domain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<SubDomain> SubDomains { get; set; }
        public ICollection<Advertisment> Advertisments { get; set; }
    }
}
