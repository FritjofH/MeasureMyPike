using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Service
{
    public class ConversionService
    {
        public Lure ConvertToLure(LureDO lureToConvert)
        {
            return new Lure {
                id = lureToConvert.Id,
                name = lureToConvert.Name
            };
        }

        public Location ConvertToLocation(LocationDO locationToConvert)
        {
            return new Location
            {
                coordinates = locationToConvert.Coordinates,
                id = locationToConvert.Id,
                lake = locationToConvert.Lake
            };
        }

        public Catch convertToCatch(CatchDO catchToConvert)
        {
            var mediaList = new List<int>();

            foreach (var media in catchToConvert.Media)
            {
                mediaList.Add(media.Id);
            }

            return new Catch
            {
                commentId = catchToConvert.Comment.Id,
                fishId = catchToConvert.Fish.Id,
                id = catchToConvert.Id,
                locationId = catchToConvert.Location.Id,
                luresId = catchToConvert.Lures.Id,
                mediaId = mediaList,
                timestamp = catchToConvert.Timestamp,
                userId = catchToConvert.User.Id,
                weatherData = catchToConvert.WeatherData.Id
            };
        }

        public User convertToUser(UserDO userToConvert)
        {
            return new User
            {
                firstName = userToConvert.FirstName,
                lastName = userToConvert.LastName,
                memberSince = userToConvert.MemberSince,
                id = userToConvert.Id,
                username = userToConvert.Username
            };
        }

        public Brand ConvertToBrand(BrandDO brandToConvert)
        {
            if (brandToConvert == null)
            {
                return null;
            }
            else
                return new Brand
                {
                    id = brandToConvert.Id
                    ,
                    name = brandToConvert.Name
                };
        }

        public Fish convertToFish(FishDO fishToConvert)
        {
            return new Fish {
                id = fishToConvert.Id,
                length = fishToConvert.Length,
                weight = fishToConvert.Weight
            };
        }
    }
}