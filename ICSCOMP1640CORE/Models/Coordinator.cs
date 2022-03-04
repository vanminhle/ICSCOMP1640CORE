using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class Coordinator
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Departments { get; set; }
    }
}
