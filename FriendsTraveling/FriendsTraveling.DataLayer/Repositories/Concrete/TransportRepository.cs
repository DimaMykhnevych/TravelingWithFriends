using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        public TransportRepository(TravelingDbContext context): base(context) { }
    }
}
