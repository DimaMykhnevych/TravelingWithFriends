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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
