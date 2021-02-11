using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class AddJourneyService : IAddJourneyService
    {
        private readonly IMapper _mapper;
        private readonly IJourneyService _journeyService;
        private readonly UserManager<AppUser> _userManager;
        public AddJourneyService(IMapper mapper,
            IJourneyService journeyService,
            UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _journeyService = journeyService;
            _userManager = userManager;
        }
        public async Task<JourneyDto> AddJourney(AddJourneyDto addJourneyDto, string currentUserName)
        {
            JourneyDto journey = addJourneyDto.Journey;
            List<LocationDto> locations = addJourneyDto.Locations.ToList();
            TransportDto transport = addJourneyDto.Transport;

            AppUser currentUser = await _userManager.FindByNameAsync(currentUserName);
            journey.OrganizerId = currentUser.Id;
            journey.UserJourneys = new List<UserJourneyDto>
            { new UserJourneyDto { AppUser = currentUser, Journey = journey } };

            RouteDto route = new RouteDto() { Transport = transport };

            journey.Route = route;

            transport.Routes = new List<RouteDto>();

            RouteLocationDto[] routeLocations = new RouteLocationDto[locations.Count];
            route.RouteLocations = routeLocations.ToList();
            for (int i = 0; i < locations.Count; i++)
            {
                route.RouteLocations[i] = new RouteLocationDto();
                route.RouteLocations[i].Location = locations[i];
                route.RouteLocations[i].LocationOrder = i + 1;
            }

            return await _journeyService.AddJourney(journey);
        }
    }
}
