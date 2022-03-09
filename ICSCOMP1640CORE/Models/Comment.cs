using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        //Foreign key UserId, comment can be give by any user
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "You should provide comment of the idea")]
        public string Content { get; set; }

    }
}
