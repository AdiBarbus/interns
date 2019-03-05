using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class SubDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual Domain Domain { get; set; }
        public virtual ICollection<Advertisment> Advertisments { get; set; }
        public virtual ICollection<QA> QAs { get; set; }

    }
}
