using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs.RouteLocationDTOs
{
    public class RouteLocationDTO
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int LocationId { get; set; }
        [Required]
        public int LocationOrder { get; set; }
    }
}
