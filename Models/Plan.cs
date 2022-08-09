namespace Voting_App.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<Vote> Votes { get; set; }
        
        
        
    }
}