using System.ComponentModel.DataAnnotations;
namespace Voting_App.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(70)]
        [Display(Name = "نام", AutoGenerateFilter=false)]  
        public string Name { get; set; }
        [Required]
        [Display(Name = "توضیح", AutoGenerateFilter=false)]  
        public string Description { get; set; }
        
        public List<Vote> Votes { get; set; }
        public User User { get; set; }
        
        
    }
}