using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectQasFKs
    {
        public IQueryable<Advertise> Advertises { get; set; }
        public int SelectedAdvertiseId { set; get; }
        public IQueryable<SubDomain> SubDomains { get; set; }
        public int SelectedSubDomainId { set; get; }
    }
}
