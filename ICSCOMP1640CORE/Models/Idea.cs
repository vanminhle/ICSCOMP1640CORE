using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSCOMP1640CORE.Models
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }



        //Foreign key Category Id
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }




        //Foreign key UserId
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }




        //Idea is specific for
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }



        //Data
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM / dd / yyyy hh: mm}")]
        public DateTime SubmitDate { get; set; }

        [Required(ErrorMessage = "Idea Name is required")]
        [StringLength(30)]
        public string IdeaName { get; set; }

        [Required(ErrorMessage = "You should provide content of the idea")]
        public string Content { get; set; }
        public byte[] Document { get; set; }

        public int View { get; set; }

        public int Rating { get; set; }

        public int ThumbUp { get; set; }

        public int ThumbDown { get; set; }

        public List<Comment> Comments { get; set; }


        public Idea()
        {
            SubmitDate = DateTime.Now;
        }

        public Boolean IsAnonymous { get; set; }

        [NotMapped]
        public string EmailCreator
        {
            get
            {
                if (IsAnonymous)
                    return "Anonymous";

                return User?.Email;
            }
        }

        [NotMapped]
        public string NameCreator
        {
            get
            {
                if (IsAnonymous)
                    return "Anonymous";

                return User?.FullName;
            }
        }

    }
}
