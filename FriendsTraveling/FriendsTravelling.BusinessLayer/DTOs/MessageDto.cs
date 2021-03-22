using FriendsTraveling.DataLayer.Models.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime SendingDate { get; set; }
        public int AppUserId { get; set; }
        public int ChatId { get; set; }
        public ChatDto Chat { get; set; }
        public AppUser Sender { get; set; }
    }
}
