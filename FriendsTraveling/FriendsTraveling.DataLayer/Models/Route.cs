using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.DataLayer.Models
{
    public class Route
    {
        public int Id { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
        public List<Journey> Journeys { get; set; }
        public List<RouteLocation> RouteLocations { get; set; }

    }
}
