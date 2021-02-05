using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
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

            //CreateMap<CreateUserRequestModel, CreateUserModel>()
            //    .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
            //    .ForMember(u => u.Username, m => m.MapFrom(u => u.Username));

            CreateMap<UpdateUserModel, AppUser>()
                .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));
            CreateMap<UpdateUserProfileDto, AppUser>()
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<Transport, TransportDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Route, RouteDto>().ReverseMap();
            CreateMap<RouteLocation, RouteLocationDto>().ReverseMap();
            CreateMap<Journey, JourneyDto>().ReverseMap();
            CreateMap<UserJourney, UserJourneyDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
