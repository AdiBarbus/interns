﻿using System.Collections.Generic;
using Interns.Core.Data;

namespace Interns.Presentation.Models
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public int SelectedRoleId { set; get; }
    }
}