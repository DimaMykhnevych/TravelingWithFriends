using System.Collections.Generic;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class RouteDto
    {
        public int Id { get; set; }

        public int TransportId { get; set; }

        public TransportDto Transport { get; set; }
        public List<JourneyDto> Journeys { get; set; }
        public List<RouteLocationDto> RouteLocations { get; set; }

        //public TransportDTO Transport { get; set; }
    }
}
