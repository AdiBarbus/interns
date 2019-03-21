using System.Collections.Generic;

namespace Interns.Presentation.Models
{ 
    public class GenericPagingViewModel<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string searchString { get; set; }
        public string sortingOrder { get; set; }
    }
}