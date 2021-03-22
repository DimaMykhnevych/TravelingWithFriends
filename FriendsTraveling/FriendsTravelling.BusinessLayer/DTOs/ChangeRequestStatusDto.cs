using FriendsTraveling.DataLayer.Enums;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class ChangeRequestStatusDto
    {
        public int RequestId { get; set; }
        public JourneyRequestStatus NewStatus { get; set; }
    }
}
