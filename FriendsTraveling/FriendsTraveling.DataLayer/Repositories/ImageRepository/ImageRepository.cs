using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Repositories.ImageRepository
{
    public class ImageRepository: Repository<Image>, IImageRepository
    {
        public ImageRepository(TravelingDbContext context):base(context)
        {

        }
    }
}
