using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class QA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        public Advertisment Advertisment { get; set; }
        public SubDomain SubDomain { get; set; }
    }
}
