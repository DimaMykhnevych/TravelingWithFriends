using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FriendsTraveling.DataLayer.Models.User
{
    public class AppUser : IdentityUser<int>
    {
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public Image ProfileImage { get; set; }

        public List<UserJourney> UserJourneys { get; set; }
        public List<UserChat> UserChats { get; set; }
        public List<JourneyRequest> JourneyRequests { get; set; }
        public List<Message> Messages { get; set; }

    }
}
