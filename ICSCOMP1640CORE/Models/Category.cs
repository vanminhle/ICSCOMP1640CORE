using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(20)]
        public string Description { get; set; }
    }
}
