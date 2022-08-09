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
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public DateTime VoteData { get; set; }
        public Date DayTime { get; set; }
        

        public Plan Plan { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}