using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class QA : BaseClass
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
