using System.ComponentModel.DataAnnotations;
namespace Voting_App.Models
{
    public enum Date
    {
        Morning,
        Noon,
        Evening,
        Night
    }
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Required]
        public DateTime VoteData { get; set; }
        [Required]
        public Date DayTime { get; set; }
        

        public Plan Plan { get; set; }
        public User User { get; set; }
    }
}