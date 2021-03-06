using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(30)]
        public string Name { get; set; }



        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }



        public List<Idea> Ideas { get; set; }
        public List<User> Users { get; set; }

        public bool IsAssignedCoordinator
        {
            get; set;
        }
    }
}
