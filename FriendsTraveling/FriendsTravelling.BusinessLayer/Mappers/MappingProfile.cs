using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.DTOs.TransportDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.BusinessLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<AppUser, AppUserDTO>().ReverseMap();

            CreateMap<CreateUserModel, AppUser>()
                .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<UpdateUserModel, AppUser>()
                .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<Transport, TransportDTO>().ReverseMap();
        }
    }
}
