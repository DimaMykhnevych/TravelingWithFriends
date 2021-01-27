using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class Transport
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Route> Routes { get; set; }

    }
}
