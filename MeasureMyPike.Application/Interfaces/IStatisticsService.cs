using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;

namespace MeasureMyPike.Service
{
    public interface IStatisticsService
    {
        List<Statistics> GetAllStatistics();
        List<Statistics> GetStatisticsForUser(User aUser);
        List<Statistics> GetStatisticsForLake(Lake aLake);
    }
}
