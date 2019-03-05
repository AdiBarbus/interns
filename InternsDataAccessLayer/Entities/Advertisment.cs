using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class Advertisment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }

        public Company Company { get; set; }
        public virtual ICollection<QA> QAs { get; set; }
    }
}
