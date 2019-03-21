using System.Collections.Generic;

namespace Interns.Web.Models
{
    public class GenericPagingViewModel<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string searchString { get; set; }
        public string sortingOrder { get; set; }
    }
}