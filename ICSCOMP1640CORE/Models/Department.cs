using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(20)]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(20)]

        public string Description { get; set; }
    }
}
