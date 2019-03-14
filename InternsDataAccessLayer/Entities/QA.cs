using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class Qa : BaseClass
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

        public int SubDomainId { get; set; }
        public int AdvertiseId { get; set; }
    }
}
