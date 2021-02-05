using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class TransportDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
