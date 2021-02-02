using FriendsTraveling.DataLayer.Models.User;

namespace FriendsTraveling.DataLayer.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
