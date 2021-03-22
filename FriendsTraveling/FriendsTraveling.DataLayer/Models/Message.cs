using FriendsTraveling.DataLayer.Models.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime SendingDate { get; set; }
        public int AppUserId { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public AppUser Sender { get; set; }
    }
}
