﻿namespace FriendsTraveling.BusinessLayer.DTOs.UserDTOs
{
    public class UpdateUserProfileDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
