using System.Data.Entity;

namespace TripApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
