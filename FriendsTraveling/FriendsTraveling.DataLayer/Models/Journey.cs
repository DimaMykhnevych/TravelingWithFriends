using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.DataLayer.Models
{
    public class Journey
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MinimumRequiredAge { get; set; }

        [Required]
        public int MaximumRequiredAge { get; set; }

        [Required]
        public int OrganizerId { get; set; }

        [Required]
        public int AvailablePlaces { get; set; }

        public List<UserJourney> UserJourneys { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public Chat Chat { get; set; }
    }
}
