using FriendsTraveling.DataLayer.Models;

namespace FriendsTraveling.DataLayer.Builders.Abstract
{
    public interface IJourneySearchQueryBuilder:IQueryBuilder<Journey>
    {
        IJourneySearchQueryBuilder SetBaseJourneyInfo();
        IJourneySearchQueryBuilder GetJourneysDependsOnCurrentUser(int userId, bool isForCurrentUser);
        IJourneySearchQueryBuilder SetJourneyPrice(int? startPrice, int? endPrice);
    }
}
