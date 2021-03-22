using FriendsTraveling.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class AddJourneyRequestDto
    {
        public int Id { get; set; }
        [Required]
        public int RequestedJourneyId { get; set; }
        [Required]
        public JourneyRequestStatus JourneyRequestStatus { get; set; }
        public int OrganizerId { get; set; }
        public int RequestUserId { get; set; }
    }
}
