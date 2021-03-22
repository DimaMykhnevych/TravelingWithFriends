namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class SearchJourneyDto
    {
        public int? StartPrice { get; set; }
        public int? EndPrice { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public bool IsForCurrentUser { get; set; }
        public int UserId { get; set; }
    }
}
