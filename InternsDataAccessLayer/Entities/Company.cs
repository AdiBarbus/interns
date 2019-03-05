using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsDataAccessLayer.Entities
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UniqueCode { get; set; }
        public string Details { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Advertisment> Advertisments { get; set; }
    }
}
