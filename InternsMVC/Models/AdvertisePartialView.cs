using InternsDataAccessLayer.Entities;

namespace InternsMVC.Models
{
    public class AdvertisePartialView
    {
        public Advertise Advertise { get; set; }
        public Domain Domain { get; set; }
        public SubDomain SubDomain { get; set; }
    }
}