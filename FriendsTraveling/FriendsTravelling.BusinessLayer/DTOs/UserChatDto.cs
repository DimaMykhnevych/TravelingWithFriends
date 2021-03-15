using FriendsTraveling.DataLayer.Models.User;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class UserChatDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ChatId { get; set; }

        public ChatDto Chat { get; set; }
        public AppUser AppUser { get; set; }
    }
}
