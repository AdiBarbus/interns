using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class Advertisment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string City { get; set; }
        public virtual ICollection<QA> QAs { get; set; }
        public User User { get; set; }
    }
}
