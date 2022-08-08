using Microsoft.AspNetCore.Identity;

namespace Voting_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Vote> Votes { get; set; }
    }
}