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
                Id = lureToConvert.Id,
                Name = lureToConvert.Name
            };
        }

        public Location ConvertToLocation(LocationDO locationToConvert)
        {
            return new Location
            {
                Coordinates = locationToConvert.Coordinates,
                Id = locationToConvert.Id,
                Lake = locationToConvert.Lake
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
                CommentId = catchToConvert.Comment.Id,
                FishId = catchToConvert.Fish.Id,
                Id = catchToConvert.Id,
                LocationId = catchToConvert.Location.Id,
                LuresId = catchToConvert.Lures.Id,
                MediaId = mediaList,
                Timestamp = catchToConvert.Timestamp,
                UserId = catchToConvert.User.Id,
                WeatherData = catchToConvert.WeatherData.Id
            };
        }

        public User convertToUser(UserDO userToConvert)
        {
            return new User
            {
                FirstName = userToConvert.FirstName,
                LastName = userToConvert.LastName,
                MemberSince = userToConvert.MemberSince,
                Id = userToConvert.Id,
                Username = userToConvert.Username
            };
        }

        public Brand ConvertToBrand(BrandDO brandToConvert)
        {
            return new Brand {
                Id = brandToConvert.Id
                , Name = brandToConvert.Name
            };
        }
    }
}