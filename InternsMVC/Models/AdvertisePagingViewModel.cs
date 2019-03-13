using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Models
{
    public class AdvertisePagingViewModel
    {
        public IEnumerable<Advertise> Advertises { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}