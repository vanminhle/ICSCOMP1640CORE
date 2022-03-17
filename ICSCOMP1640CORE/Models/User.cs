using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(30)]
        public string FullName { get; set; }

        [StringLength(40)]
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        /* User can have their Department Id Assign */

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }

    public enum Gender
    {
        Male,
        Female
    }
}
