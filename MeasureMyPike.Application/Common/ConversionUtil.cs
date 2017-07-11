using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Application.Common
{
    public class ConversionUtil
    {
        public Lure ConvertToLure(LureDO lureToConvert)
        {
            if (lureToConvert == null)
            {
                return null;
            }
            return new Lure {
                Id = lureToConvert.Id,
                Name = lureToConvert.Name,
                Weight = (int)lureToConvert.Weight,
                Colour = lureToConvert.Colour,
                BrandId = lureToConvert.Brand.Id
            };
        }

        public Location ConvertToLocation(LocationDO locationToConvert)
        {
            if (locationToConvert == null)
            {
                return null;
            }
            return new Location
            {
                Coordinates = locationToConvert.Coordinates,
                Id = locationToConvert.Id,
            };
        }

        public Lake ConvertToLake(LakeDO lakeToConvert)
        {
            if (lakeToConvert == null)
            {
                return null;
            }
            return new Lake
            {
                Name = lakeToConvert.Name,
                Id = lakeToConvert.Id,
            };
        }

        public Catch ConvertToCatch(CatchDO catchToConvert)
        {
            if (catchToConvert == null)
            {
                return null;
            }
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
                LureId = catchToConvert.Lure.Id,
                MediaId = mediaList,
                Timestamp = catchToConvert.Timestamp,
                UserId = catchToConvert.User.Id,
                WeatherData = catchToConvert.WeatherData.Id,
            };
        }

        public User ConvertToUser(UserDO userToConvert)
        {
            if (userToConvert == null)
            {
                return null;
            }
            return new User
            {
                Firstname = userToConvert.FirstName,
                Lastname = userToConvert.LastName,
                MemberSince = userToConvert.MemberSince,
                Id = userToConvert.Id,
                Username = userToConvert.Username
            };
        }

        public TackleBox ConvertToTackleBox(TackleBoxDO tackleBoxToConvert)
        {
            if (tackleBoxToConvert == null)
            {
                return null;
            }
            return new TackleBox
            {
                Id = tackleBoxToConvert.Id,
                DatePurchased = tackleBoxToConvert.DatePurchased
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
                    Id = brandToConvert.Id,
                    Name = brandToConvert.Name
                };
        }

        public Fish ConvertToFish(FishDO fishToConvert)
        {
            if (fishToConvert == null)
            {
                return null;
            }
            return new Fish {
                Id = fishToConvert.Id,
                Length = (int)fishToConvert.Length,
                Weight = (int)fishToConvert.Weight
            };
        }
    }
}