using System.Linq;

namespace FriendsTraveling.DataLayer.Builders.Abstract
{
    public interface IQueryBuilder<TEntity>
    {
        IQueryable<TEntity> Build();
    }
}
