using System.ComponentModel.DataAnnotations;
namespace Voting_App.Models
{
    
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime VoteData { get; set; }
        [Required]
        public Date DayTime { get; set; }
        
        

        public Plan Plan { get; set; }
        public User User { get; set; }


        public enum Date
        {
        Morning,
        Noon,
        Evening,
        Night
        }
    }
}