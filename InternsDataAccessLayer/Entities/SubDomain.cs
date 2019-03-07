using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace InternsDataAccessLayer.Entities
{
    public class SubDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IQueryable<Advertisment> Advertisments { get; set; }
        public IQueryable<QA> QAs { get; set; }
    }
}
