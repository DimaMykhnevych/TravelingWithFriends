using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.DataLayer.Repositories.TransportRepository
{
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        public TransportRepository(TravelingDbContext context): base(context) { }
    }
}
