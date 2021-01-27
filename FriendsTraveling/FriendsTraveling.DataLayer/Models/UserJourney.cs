using FriendsTraveling.DataLayer.Models.User;

namespace FriendsTraveling.DataLayer.Models
{
    public class UserJourney
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int JourneyId { get; set; }

        public Journey Journey { get; set; }
        public AppUser AppUser { get; set; }
    }
}
