using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(20)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        public int Age { get; set; }
    }
}
