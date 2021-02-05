using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class CreateUserModel
    {
        public string Role { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}
