using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class ImageRepository: Repository<Image>, IImageRepository
    {
        public ImageRepository(TravelingDbContext context):base(context)
        {

        }
    }
}
