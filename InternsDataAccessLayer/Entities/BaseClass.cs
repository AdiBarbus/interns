using System.ComponentModel.DataAnnotations.Schema;

namespace InternsDataAccessLayer.Entities
{
    public class BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
