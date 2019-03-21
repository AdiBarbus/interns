using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Role : BaseEntity
    {
        [Required]
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}