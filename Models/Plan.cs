using System.ComponentModel.DataAnnotations;
namespace Voting_App.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public List<Vote> Votes { get; set; }
        public List<User> Users { get; set; }
        
        
    }
}