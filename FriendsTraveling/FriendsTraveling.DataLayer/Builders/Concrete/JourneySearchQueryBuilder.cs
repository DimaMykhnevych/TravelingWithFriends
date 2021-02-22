using FriendsTraveling.DataLayer.Builders.Abstract;
using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FriendsTraveling.DataLayer.Builders.Concrete
{
    public class JourneySearchQueryBuilder : IJourneySearchQueryBuilder
    {
        private readonly TravelingDbContext _context;
        private IQueryable<Journey> _query;

        public JourneySearchQueryBuilder(TravelingDbContext context) => _context = context;
        public IQueryable<Journey> Build()
        {
            IQueryable<Journey> result = _query;
            _query = null;
            return result;
        }

        public IJourneySearchQueryBuilder SetBaseJourneyInfo()
        {
            _query =  _context.Journeys
             .Include(j => j.Route)
             .Include(j => j.UserJourneys)
             .ThenInclude(uj => uj.AppUser)
             .ThenInclude(u => u.ProfileImage)
             .Include(j => j.Route.Transport)
             .Include(j => j.Route.RouteLocations)
             .ThenInclude(j => j.Location);
            return this;
        }

        public IJourneySearchQueryBuilder GetJourneysDependsOnCurrentUser(int userId, bool isForCurrentUser)
        {
            if (isForCurrentUser)
            {
                _query = _query.Where(j => j.OrganizerId == userId);
            }
            else
            {
                _query = _query.Where(j => j.OrganizerId != userId);
            }
            return this;
        }

        public IJourneySearchQueryBuilder SetJourneyPrice(int? startPrice, int? endPrice)
        {
            if (startPrice == null && endPrice != null)
            {
                _query = _query.Where(j => j.Price <= endPrice);
            }
            else if (endPrice == null && startPrice != null)
            {
                _query = _query.Where(j => j.Price >= startPrice);
            }
            else if (endPrice != null && startPrice != null)
            {
                _query = _query.Where(j => j.Price >= startPrice
               && j.Price <= endPrice);
            }
            return this;
        }

        public IJourneySearchQueryBuilder SetJourneyRequiredAge(int? minAge, int? maxAge)
        {

            if (minAge == null && maxAge != null)
            {
                _query = _query.Where(j => j.MaximumRequiredAge <= maxAge);
            }
            else if (maxAge == null && minAge != null)
            {
                _query = _query.Where(j => j.MinimumRequiredAge >= minAge);
            }
            else if (maxAge != null && minAge != null)
            {
                _query = _query.Where(j => j.MinimumRequiredAge >= minAge
               && j.MaximumRequiredAge <= maxAge);
            }
            return this;
        }
    }
}
