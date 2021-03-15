using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class Chat
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int JourneyChatId { get; set; }

        public List<UserChat> UserChats { get; set; }
        public Journey Journey { get; set; }
        public List<Message> Messages { get; set; }
    }
}
