namespace FriendsTraveling.DataLayer.Models.Auth
{
    public class UserAuthInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ProfileImagePath { get; set; }
    }
}
