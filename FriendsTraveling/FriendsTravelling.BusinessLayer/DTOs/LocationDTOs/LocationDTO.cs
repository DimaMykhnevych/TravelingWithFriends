using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs.LocationDTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
