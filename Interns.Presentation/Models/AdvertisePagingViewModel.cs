using System.Collections.Generic;
using Interns.Core.Data;

namespace Interns.Presentation.Models
{
    public class AdvertisePagingViewModel
    {
        public IEnumerable<Advertise> Advertises { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}