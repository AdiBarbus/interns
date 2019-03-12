using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Models
{
    public class DomainSubdomain
    {
        public IEnumerable<SubDomain> SubDomains { get; set; }
        public Domain Domain { get; set; }
    }
}