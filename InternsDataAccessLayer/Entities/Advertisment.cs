using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace InternsDataAccessLayer.Entities
{
    public class Advertisment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public IQueryable<QA> QAs { get; set; }
    }
}
