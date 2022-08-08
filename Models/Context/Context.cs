using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Voting_App.Models;


namespace Models.Context {
    public class Context : IdentityDbContext<ApplicationUser> {
        public Context (DbContextOptions options) : base (options) 
        {

        }
        
        public DbSet<Vote> Votes { get; set; }

        
    }
}