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
                Statistics stat = new Statistics
                {
                    CatchId = aCatch.Id,
                    UserId = aCatch.User.Id,
                    Comment = aCatch.Comment.Text,
                    FishId = aCatch.Fish.Id,
                    LocationId = aCatch.Location.Id,
                    LureId = aCatch.Lure.Id,
                    AirTemperature = aCatch.WeatherData.AirTemperature,
                    WaterTemperature = aCatch.WeatherData.WaterTemperature,
                    Weather = aCatch.WeatherData.Weather,
                    MoonPhase = aCatch.WeatherData.MoonPosition                    
                };

                statList.Add(stat);

            }

            return statList;
        }

        public List<Statistics> GetStatisticsForLake(Lake aLake)
        {
            int lakeId = aLake.Id;
            var lakeRepo = new LakeRepository();
            var lakeDO = lakeRepo.GetLake(aLake.Id);
            var catchRepo = new CatchRepository();
            var conversionService = new ConversionUtil();

            var statList = new List<Statistics>();
            List<CatchDO> catchList = catchRepo.GetCatches(lakeDO);
            if (catchList == null)
            {
                // If no catches, return empty list
                return statList;
            }

            foreach (var aCatch in catchList)
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

                statList.Add(stat);

            }

            return statList;
        }

    }
}
