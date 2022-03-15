using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Category Description")]

        public string Description { get; set; }
    }
}
