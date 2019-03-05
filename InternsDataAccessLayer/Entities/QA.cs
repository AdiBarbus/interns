using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class QA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public Advertisment Advertisment { get; set; }
        public SubDomain SubDomain { get; set; }
    }
}
