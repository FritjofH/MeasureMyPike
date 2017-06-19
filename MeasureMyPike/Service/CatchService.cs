using MeasureMyPike;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;

public class CatchService
{
    public Catch CreateCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, string username)
    {
        var catchRepo = new CatchRepository();
        var ls = new LureService();
        var mediaList = new List<MediaDO>();
        var userService = new UserService();

        mediaList.Add(new MediaDO
        {
            MediaFormat = format,
            Image = new MediaDataDO
            {
                Length = image.Length,
                Data = image
            }
        });


        var newCatch = new CatchDO
        {
            User = userService.GetUserDO("hostf"),
            Comment = new CommentDO { Text = comment },
            Media = mediaList,
            Lures = ls.GetLureDO(lure.Id),
            Fish = new FishDO { Length = fishLength, Weight = fishWeight },
            Location = new LocationDO { Lake = lake, Coordinates = coordinates },
            WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = DateTime.Now    // TODO: kanske skicka med istället = fångades
        };

        var createdCatch = catchRepo.AddCatch(newCatch);

        return convertToCatch(createdCatch);
    }

    public bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        var catchRepo = new CatchRepository();
        var ls = new LureService();

        var catchToUpdate = catchRepo.GetCatch(id);
        catchToUpdate.Comment = new CommentDO { Text = comment };
        catchToUpdate.Media.Add(new MediaDO { MediaFormat = format, Image = new MediaDataDO { Length=image.Length, Data=image} });
        catchToUpdate.Lures = ls.GetLureDO(lure.Id);
        catchToUpdate.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        catchToUpdate.Location = new LocationDO { Lake = lake, Coordinates = coordinates};
        catchToUpdate.WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        catchToUpdate.Timestamp = DateTime.Now; // TODO: kanske skicka med istället
        
        var updatedCatch = catchRepo.UpdateCatch(id, catchToUpdate);

        return updatedCatch;
    }

    public List<Catch> GetAllCatches()
    {
        var catchRepo = new CatchRepository();
        var catchList = new List<Catch>(); 

        foreach (var catchDO in catchRepo.GetAllCatch())
        {
            catchList.Add(convertToCatch(catchDO));
        }

        return catchList;
    }

    public Catch GetCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);

        return convertToCatch(selectedCatch);
    }
    public CatchDO GetCatchDO(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);

        return selectedCatch;
    }

    public bool DeleteCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var catchToDelete = GetCatchDO(id);
        var deleted = catchRepo.DeleteCatch(catchToDelete);

        return deleted;
    }

    private Catch convertToCatch(CatchDO catchToConvert)
    {
        var mediaList = new List<int>();

        if (catchToConvert.Media.Count > 0)
        {
            foreach (var media in catchToConvert.Media)
            {
                mediaList.Add(media.Id);
            }
        }

        var catchToReturn = new Catch
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

        return catchToReturn;
    }
}
