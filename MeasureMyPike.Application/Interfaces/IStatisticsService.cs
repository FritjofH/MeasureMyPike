using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;

namespace MeasureMyPike.Service
{
    public interface IStatisticsService
    {
        List<Statistics> GetAllStatistics();
        List<Statistics> CatchesForUser(UserDO userDO);
        List<Statistics> CatchesForUser(int userId);
        List<Statistics> CatchesForUser(string userName);
        List<Statistics> CatchesForLake(LakeDO lakeDO);
        List<Statistics> CatchesForLake(int lakeId);
        List<Statistics> CatchesForLake(string lakeName);
        List<LakeStatistics> LakeTopList(DateTime startDate);
        List<Statistics> FishTopList(DateTime startDate);
    }
}
