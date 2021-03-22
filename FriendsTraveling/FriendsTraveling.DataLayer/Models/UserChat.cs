using FriendsTraveling.DataLayer.Models.User;

namespace FriendsTraveling.DataLayer.Models
{
    public class UserChat
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ChatId { get; set; }

        public Chat Chat { get; set; }
        public AppUser AppUser { get; set; }
    }
}
