using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;

namespace MeasureMyPike.Service
{
    public interface IStatisticsService
    {
        List<Statistics> GetAllStatistics();
        List<Statistics> CatchesForUser(User aUser);
        List<Statistics> CatchesForLake(Lake aLake);
        List<LakeStatistics> LakeTopList(DateTime startDate);
        List<Statistics> FishTopList(DateTime startDate);
    }
}
