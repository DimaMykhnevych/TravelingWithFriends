﻿using System.ComponentModel.DataAnnotations;

namespace FriendsTraveling.BusinessLayer.DTOs.TransportDTOs
{
    public class TransportDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}