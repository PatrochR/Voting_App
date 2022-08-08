namespace Voting_App.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public DateTime VoteData { get; set; }
        
        
        public List<ApplicationUser> Users { get; set; }
    }
}