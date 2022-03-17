using System.ComponentModel.DataAnnotations;

namespace ICSCOMP1640CORE.Models
{
    public class UserActionOnIdea
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        public bool IsLike { get; set; }

        public bool IsDisLike { get; set; }
    }
}
