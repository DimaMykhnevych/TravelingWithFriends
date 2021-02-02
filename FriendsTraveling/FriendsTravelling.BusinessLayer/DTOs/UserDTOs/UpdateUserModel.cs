using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs.UserDTOs
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
       
        [Required]
        public string Username { get; set; }
        public string Role { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Age { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
        [MinLength(6)]
        public string NewPassword { get; set; }
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}
