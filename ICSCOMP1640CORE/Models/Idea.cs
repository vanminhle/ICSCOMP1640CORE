using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }

        //Foreign key Category Id
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        //Foreign key UserId
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Staff Staff { get; set; }

        //Data

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SubmitDate { get; set; }

        [Required(ErrorMessage = "Idea Name is required")]
        [StringLength(20)]
        public string IdeaName { get; set; }

        [Required(ErrorMessage = "You should provide content of the idea")]
        public string IdeaContent { get; set; }
        public byte[] Document { get; set; }

        public int View { get; set; }

        public int Rating { get; set; }

    }
}
