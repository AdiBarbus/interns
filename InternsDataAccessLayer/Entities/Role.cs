using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class Role : BaseClass
    {
        [Required]
        public string Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}