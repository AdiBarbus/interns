using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Zip { get; set; }

        public virtual Company Company { get; set; }
    }
}
