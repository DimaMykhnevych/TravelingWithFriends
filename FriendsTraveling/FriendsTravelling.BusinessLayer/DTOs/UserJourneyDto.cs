using FriendsTraveling.DataLayer.Models.User;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class UserJourneyDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int JourneyId { get; set; }

        public JourneyDto Journey { get; set; }
        public AppUser AppUser { get; set; }
    }
}
