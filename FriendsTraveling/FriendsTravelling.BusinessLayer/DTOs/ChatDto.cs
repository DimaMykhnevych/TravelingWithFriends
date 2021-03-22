using FriendsTraveling.DataLayer.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class ChatDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int JourneyChatId { get; set; }

        public List<UserChatDto> UserChats { get; set; }
        public JourneyDto Journey { get; set; }
        public List<MessageDto> Messages { get; set; }
        public AppUser JourneyCreator { get; set; }
    }
}
