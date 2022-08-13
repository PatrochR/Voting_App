using Microsoft.EntityFrameworkCore;
using Voting_App.Models;


namespace Models.Context {
    public class Context : DbContext {
        public Context (DbContextOptions options) : base (options) 
        {

        }
        
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}