﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Repo;
using MeasureMyPike.Application.Common;

namespace MeasureMyPike.Service
{
    public class StatisticsService : IStatisticsService
    {
        public List<Statistics> GetAllStatistics()
        {
            var catchRepo = new CatchRepository();

            var statList = new List<Statistics>();

            foreach (var aCatch in catchRepo.GetAllCatches())
            {
                Statistics stat = PopulateFromCatch(aCatch);

                statList.Add(stat);

            }

            return statList;
        }

        public List<Statistics> CatchesForLake(Lake aLake)
        {
            int lakeId = aLake.Id;
            var lakeRepo = new LakeRepository();
            var catchRepo = new CatchRepository();

            var lakeDO = lakeRepo.GetLake(aLake.Id);
            List<CatchDO> catchList = catchRepo.GetCatches(lakeDO);

            var statList = new List<Statistics>();
            if (catchList == null)
            {
                // If no catches, return empty list
                return statList;
            }

            foreach (var aCatch in catchList)
            {
                Statistics stat = PopulateFromCatch(aCatch);

                statList.Add(stat);

            }

            return statList;
        }

        public List<Statistics> CatchesForUser(User aUser)
        {
            int userId = aUser.Id;
            var userRepo = new UserRepository();
            var userDO = userRepo.GetUser(aUser.Id);
            var catchRepo = new CatchRepository();

            var statList = new List<Statistics>();
            List<CatchDO> catchList = catchRepo.GetCatches(userDO);
            if (catchList == null)
            {
                // If no catches, return empty list
                return statList;
            }

            foreach (var aCatch in catchList)
            {
                Statistics stat = PopulateFromCatch(aCatch);

                statList.Add(stat);

            }

            return statList;
        }

        // List of best lakes (kg fish) since startdate
        public List<LakeStatistics> LakeTopList(DateTime startDate)
        {
            List<LakeStatistics> lakeList = new List<LakeStatistics>();

            var statList = GetAllStatistics();
            
            // first get all since startdate
            statList = statList.
                Where(ob => ob.Timestamp >= startDate).
                ToList();

            // extract lakes list
            foreach (var stat in statList)
            {
                // this lake exist in list?
                LakeStatistics ls = lakeList.Find(x => x.LakeId == stat.LakeId);

                if (ls != null)
                {
                    // lake is known, add catch and total measures
                    ls.CatchId.Add(stat.CatchId);
                    ls.TotalFishLength += stat.FishLength;
                    ls.TotalFishWeight += stat.FishWeight;
                }
                else
                {
                    // lake not previously found, insert in list
                    var idList = new List<int>() { stat.CatchId };

                    ls = new LakeStatistics
                    {
                        LakeId = stat.LakeId,
                        LakeName = stat.LakeName,
                        CatchId = idList,
                        LocationId = stat.LocationId,
                        LocationCoordinates = stat.LocationCoordinates,
                        TotalFishLength = stat.FishLength,
                        TotalFishWeight = stat.FishWeight
                    };
                }

                lakeList.Add(ls);
            }

            // order by total fisk weight
            lakeList = lakeList.OrderByDescending(ob => ob.TotalFishWeight).ToList(); ;

            return lakeList;
        }

        // List of catches since startdate ordered by weight
        public List<Statistics> FishTopList(DateTime startDate)
        {
            var statList = GetAllStatistics();

            // get all since startdate and sort by fish weight desc
            statList = statList.
                Where(ob => ob.Timestamp >= startDate).
                OrderByDescending(ob => ob.FishWeight).
                ToList();

            return statList;
        }

        private Statistics PopulateFromCatch(CatchDO aCatch)
        {
            Statistics stat = new Statistics
            {
                Id = aCatch.Id,
                Timestamp = aCatch.Timestamp,
                CatchId = aCatch.Id,
                UserId = aCatch.User.Id,
                UserName = aCatch.User.Username,
                Comment = aCatch.Comment.Text,
                FishId = aCatch.Fish.Id,
                FishLength = (int)aCatch.Fish.Length,
                FishWeight = (int)aCatch.Fish.Weight,
                LocationId = aCatch.Location.Id,
                LocationCoordinates = aCatch.Location.Coordinates,
                LakeId = aCatch.Location.Lake.Id,
                LakeName = aCatch.Location.Lake.Name,
                LureId = aCatch.Lure.Id,
                LureName = aCatch.Lure.Name,
                LureBrand = aCatch.Lure.Brand.Name,
                LureWeight = aCatch.Lure.Weight,
                AirTemperature = aCatch.WeatherData.AirTemperature,
                WaterTemperature = aCatch.WeatherData.WaterTemperature,
                Weather = aCatch.WeatherData.Weather,
                MoonPhase = aCatch.WeatherData.MoonPosition
            };

            return stat;
        }

    }
}
