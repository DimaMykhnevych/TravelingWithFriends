using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class RouteLocation
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int LocationId { get; set; }
        [Required]
        public int LocationOrder { get; set; }

        public Route Route { get; set; }
        public Location Location { get; set; }

    }
}
