using System.ComponentModel.DataAnnotations;

namespace Voting_App.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserNameConfirmed { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public List<Vote> Votes { get; set; }
        public List<Plan> Plans { get; set; }
    }
}