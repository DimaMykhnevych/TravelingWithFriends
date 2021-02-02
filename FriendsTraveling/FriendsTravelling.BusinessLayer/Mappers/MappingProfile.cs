using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs.UserDTOs;
using FriendsTraveling.BusinessLayer.DTOs.JourneyDTO;
using FriendsTraveling.BusinessLayer.DTOs.LocationDTOs;
using FriendsTraveling.BusinessLayer.DTOs.RouteDTOs;
using FriendsTraveling.BusinessLayer.DTOs.RouteLocationDTOs;
using FriendsTraveling.BusinessLayer.DTOs.TransportDTOs;
using FriendsTraveling.BusinessLayer.DTOs.UserJourneyDTOs;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.User;

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
            CreateMap<UpdateUserProfileDTO, AppUser>()
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<Transport, TransportDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Route, RouteDTO>().ReverseMap();
            CreateMap<RouteLocation, RouteLocationDTO>().ReverseMap();
            CreateMap<Journey, JourneyDTO>().ReverseMap();
            CreateMap<UserJourney, UserJourneyDTO>().ReverseMap();
        }
    }
}
