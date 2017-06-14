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

        var mediaList = new List<MediaDO>();
        mediaList.Add(new MediaDO
        {
            MediaFormat = format,
            Image = new MediaDataDO
            {
                Length = image.Length,
                Data = image
            }
        });

        var ls = new LureService();

        var newCatch = new CatchDO
        {
            //User = user,
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

        var c = catchRepo.GetCatch(id);
        c.Comment = new CommentDO { Text = comment };
        c.Media.Add(new MediaDO { MediaFormat = format, Image = new MediaDataDO { Length=image.Length, Data=image} });
        c.Lures = ls.GetLureDO(lure.Id);
        c.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        c.Location = new LocationDO { Lake = lake, Coordinates = coordinates};
        c.WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        c.Timestamp = DateTime.Now; // TODO: kanske skicka med istället
        
        var updatedCatch = catchRepo.UpdateCatch(id, c);

        return updatedCatch;
    }

    public List<Catch> GetAllCatch()
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

    public bool DeleteCatch(int id)
    {
        var catchRepo = new CatchRepository();

        var deleted = catchRepo.DeleteCatch(id);

        return deleted;
    }

    private Catch convertToCatch(CatchDO catchToConvert)
    {
        var medias = new List<int>();

        foreach (var media in catchToConvert.Media)
        {
            medias.Add(media.Id);
        }

        var catchToReturn = new Catch
        {
            CommentId = catchToConvert.Comment.Id,
            FishId = catchToConvert.Fish.Id,
            Id = catchToConvert.Id,
            LocationId = catchToConvert.Location.Id,
            LuresId = catchToConvert.Lures.Id,
            MediaId = medias,
            Timestamp = catchToConvert.Timestamp,
            UserId = catchToConvert.User.Id,
            WeatherData = catchToConvert.WeatherData.Id
        };

        return catchToReturn;
    }
}
