using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.BusinessLayer.DTOs
{
    public class AddJourneyDto
    {
        public JourneyDto Journey { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }
        public TransportDto Transport { get; set; }
    }
}
