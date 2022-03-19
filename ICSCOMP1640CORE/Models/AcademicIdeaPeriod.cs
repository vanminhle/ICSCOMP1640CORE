using System;
using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class AcademicIdeaPeriod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public int AcademicYear { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Closure Date")]

        public DateTime ClosureDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Final Closure Date")]

        public DateTime FinalClosureDate { get; set; }
    }
}
