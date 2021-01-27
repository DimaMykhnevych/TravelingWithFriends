using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.DataLayer.Repositories.LocationRepository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(TravelingDbContext context) : base(context) { }
    }
}
