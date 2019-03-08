using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Models
{
    public class UserRole
    {
        public ICollection<User> Users { get; set; }
        public Role Roles { get; set; }
    }
}