using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternsDataAccessLayer.Entities
{
    public class User : BaseClass
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string University { get; set; }
        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Advertise> Advertises { get; set; }
    }
}
