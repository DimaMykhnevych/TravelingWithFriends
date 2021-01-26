using Microsoft.AspNetCore.Identity;

namespace FriendsTraveling.DataLayer.Models.User
{
    public class AppUser : IdentityUser<int>
    {
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
    }
}
