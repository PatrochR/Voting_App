using System.ComponentModel.DataAnnotations;

namespace Voting_App.Models
{
    public class PlanToUser
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PlanId { get; set; }


        public Plan Plan { get; set; }
        public User Users { get; set; }

    }
}