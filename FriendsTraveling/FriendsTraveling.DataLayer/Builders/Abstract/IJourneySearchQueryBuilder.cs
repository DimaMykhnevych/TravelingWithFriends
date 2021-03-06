﻿using FriendsTraveling.DataLayer.Models;
using System.Collections.Generic;

namespace FriendsTraveling.DataLayer.Builders.Abstract
{
    public interface IJourneySearchQueryBuilder:IQueryBuilder<Journey>
    {
        IJourneySearchQueryBuilder SetBaseJourneyInfo();
        IJourneySearchQueryBuilder GetJourneysDependsOnCurrentUser(int userId, bool isForCurrentUser);
        IJourneySearchQueryBuilder SetJourneyPrice(int? startPrice, int? endPrice);
        IJourneySearchQueryBuilder SetJourneyRequiredAge(int? minAge, int? maxAge);
    }
}
