using FriendsTraveling.DataLayer.Enums;
using FriendsTraveling.DataLayer.Models.User;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class JourneyRequestDto
    {
        public int Id { get; set; }
        [Required]
        public int RequestedJourneyId { get; set; }
        [Required]
        public JourneyRequestStatus JourneyRequestStatus { get; set; }
        public int OrganizerId { get; set; }
        public int RequestUserId { get; set; }
        public AppUser Organizer { get; set; }
        public AppUser RequestUser { get; set; }
    }
}
