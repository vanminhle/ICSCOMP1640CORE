using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        //Foreign key UserId

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Staff Staff { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CommentDate { get; set; }

        [Required(ErrorMessage = "You should provide comment of the idea")]
        public string CommentText { get; set; }

    }
}
