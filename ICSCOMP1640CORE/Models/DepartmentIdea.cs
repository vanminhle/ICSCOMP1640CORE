using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class DepartmentIdea
    {
        [Key]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        //Foreign key Idea Table
        public int IdeaId { get; set; }

        [ForeignKey("IdeaId")]
        public Idea Idea { get; set; }


    }
}
