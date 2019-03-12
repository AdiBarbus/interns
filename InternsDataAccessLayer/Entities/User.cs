using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class User : BaseClass
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string University { get; set; }
        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Advertise> Advertises { get; set; }
    }
}
