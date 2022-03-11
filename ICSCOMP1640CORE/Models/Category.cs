using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(20)]
        [Display(Name = "Category Description")]

        public string Description { get; set; }
        public List<Idea> Ideas { get; set; }
    }
}
