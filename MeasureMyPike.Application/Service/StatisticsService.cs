using System;
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
            var conversionService = new ConversionUtil();

            var statList = new List<Statistics>();

            foreach (var aCatch in catchRepo.GetAllCatches())
            {
                Statistics stat = PopulateFromCatch(aCatch);

                statList.Add(stat);

            }

            return statList;
        }

        public List<Statistics> GetStatisticsForLake(Lake aLake)
        {
            int lakeId = aLake.Id;
            var lakeRepo = new LakeRepository();
            var catchRepo = new CatchRepository();
            var conversionService = new ConversionUtil();

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

        public List<Statistics> GetStatisticsForUser(User aUser)
        {
            int userId = aUser.Id;
            var userRepo = new UserRepository();
            var userDO = userRepo.GetUser(aUser.Id);
            var catchRepo = new CatchRepository();
            var conversionService = new ConversionUtil();

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
                FishLength = aCatch.Fish.Length,
                FishWeight = aCatch.Fish.Weight,
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
