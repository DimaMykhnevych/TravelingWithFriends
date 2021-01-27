using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendsTraveling.DataLayer.DbContext
{
    public class TravelingDbContext : IdentityDbContext<AppUser, UserRole, int>
    {
        public TravelingDbContext(DbContextOptions<TravelingDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<UserJourney> UserJourneys { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RouteLocation> RouteLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
