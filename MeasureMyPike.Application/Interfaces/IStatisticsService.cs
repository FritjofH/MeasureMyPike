using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;

namespace MeasureMyPike.Service
{
    public interface IStatisticsService
    {
        List<Statistics> GetAllStatistics();
        List<Statistics> CatchesForUser(int userId, DateTime startDate);
        List<Statistics> CatchesForUser(string userName, DateTime startDate);
        List<Statistics> CatchesForLake(int lakeId, DateTime startDate);
        List<Statistics> CatchesForLake(string lakeName, DateTime startDate);
        List<LakeStatistics> LakeTopList(DateTime startDate);
        List<Statistics> FishTopList(DateTime startDate);
        List<Statistics> LatestCatches(int num);
    }
}
