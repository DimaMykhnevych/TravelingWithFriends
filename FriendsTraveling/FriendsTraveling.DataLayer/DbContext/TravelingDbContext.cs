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
        public DbSet<Image> Images { get; set; }
        public DbSet<JourneyRequest> JourneyRequests { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JourneyRequest>().HasOne(m => m.Organizer)
                                 .WithMany(m => m.JourneyRequests).HasForeignKey(m => m.OrganizerId);
            builder.Entity<JourneyRequest>().HasOne(m => m.RequestUser)
                                        .WithMany().HasForeignKey(m => m.RequestUserId);
            builder.Entity<Journey>()
                .HasOne<Chat>(j => j.Chat)
                .WithOne(c => c.Journey)
                .HasForeignKey<Chat>(c => c.JourneyChatId);

            base.OnModelCreating(builder);
        }
    }
}
