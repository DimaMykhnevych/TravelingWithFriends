using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        [Required]
        public string Country { get; set; }

        public List<RouteLocation> RouteLocations {get; set; }
    }
}
