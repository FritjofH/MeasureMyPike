using MeasureMyPike;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;

public class CatchService : ICatchService
{
    public Catch AddCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, string username)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();
        var mediaList = new List<MediaDO>();
        var conversionService = new ConversionService();
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
            User = userService.GetUserDO(username),
            Comment = new CommentDO { Text = comment },
            Media = mediaList,
            Lures = lureService.GetLureDO(lure.Id),
            Fish = new FishDO { Length = fishLength, Weight = fishWeight },
            Location = new LocationDO { Lake = lake, Coordinates = coordinates },
            WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = DateTime.Now    // TODO: kanske skicka med istället = fångades
        };

        var createdCatch = catchRepo.AddCatch(newCatch);

        return conversionService.ConvertToCatch(createdCatch);
    }

    public Catch GetCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);
        var conversionService = new ConversionService();

        return conversionService.ConvertToCatch(selectedCatch);
    }
    public CatchDO GetCatchDO(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);

        return selectedCatch;
    }

    public List<Catch> GetAllCatches()
    {
        var catchRepo = new CatchRepository();
        var catchList = new List<Catch>();
        var conversionService = new ConversionService();

        foreach (var catchDO in catchRepo.GetAllCatch())
        {
            catchList.Add(conversionService.ConvertToCatch(catchDO));
        }

        return catchList;
    }

    // TODO: Här borde vi tänka om.
    // När man bara ska ändra tex kommentaren så ska den väl inte skapa en ny MediaDO, ny FishDO, ny LocationDO och ny WeatherDO utan bara ändra det som är icke null tex.???
    //
    public bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();

        var catchToUpdate = catchRepo.GetCatch(id);

        if (catchToUpdate.Comment != null)
        {
            catchToUpdate.Comment.Text = comment;
        }
        else
        {
            catchToUpdate.Comment = new CommentDO { Text = comment };
        }
        
        catchToUpdate.Media.Add(new MediaDO { MediaFormat = format, Image = new MediaDataDO { Length = image.Length, Data = image } });
        catchToUpdate.Lures = lureService.GetLureDO(lure.Id);
        catchToUpdate.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        catchToUpdate.Location = new LocationDO { Lake = lake, Coordinates = coordinates };
        catchToUpdate.WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        catchToUpdate.Timestamp = DateTime.Now; // TODO: kanske skicka med istället

        return catchRepo.UpdateCatch(id, catchToUpdate);
    }

    public bool DeleteCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var catchToDelete = GetCatchDO(id);
        var deleted = catchRepo.DeleteCatch(catchToDelete);

        return deleted;
    }

    private Catch ConvertToCatch(CatchDO catchToConvert)
    {
        var mediaList = new List<int>();

        foreach (var media in catchToConvert.Media)
        {
            mediaList.Add(media.Id);
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
