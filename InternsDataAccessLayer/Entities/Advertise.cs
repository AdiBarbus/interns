using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class Advertise : BaseClass
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string City { get; set; }
        public User User { get; set; }
        public Domain Domain { get; set; }
        public ICollection<QA> QAs { get; set; }
    }
}
