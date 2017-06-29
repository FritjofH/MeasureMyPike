using MeasureMyPike;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;

public class CatchService : ICatchService
{
    public Catch AddCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lakeName, string coordinates, int waterTemperature, string weather, string username, params string[] additionalInformation)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();
        var lakeService = new LakeService();
        var locationService = new LocationService();
        var mediaList = new List<MediaDO>();
        var conversionService = new ConversionService();
        var userService = new UserService();
        string moonposition = ""; 
        if (additionalInformation.Length > 0)
        {
            moonposition = additionalInformation[0];
        }

        mediaList.Add(new MediaDO
        {
            MediaFormat = format,
            Image = new MediaDataDO
            {
                Length = image.Length,
                Data = image
            }
        });

        LakeDO lakeDO = lakeService.GetLakeDO(lakeName);
        //Location location = locationService.AddLocation(lakeName, coordinates);

        var newCatch = new CatchDO
        {
            User = userService.GetUserDO(username),
            Comment = new CommentDO { Text = comment },
            Media = mediaList,
            Lures = lureService.GetLureDO(lure.Id),
            Fish = new FishDO { Length = fishLength, Weight = fishWeight },
            Location = new LocationDO { Lake = lakeDO, Coordinates = coordinates },
            WeatherData = new WeatherDataDO { Temperature = waterTemperature, Weather = weather, MoonPosition = moonposition },
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
    public bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int waterTemperature, string weather, string username, params string[] additionalInformation)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();
        var lakeService = new LakeService();

        string moonposition = "";
        if (additionalInformation.Length > 0)
        {
            moonposition = additionalInformation[0];
        }

        var catchToUpdate = catchRepo.GetCatch(id);

        if (catchToUpdate.Comment != null)
        {
            catchToUpdate.Comment.Text = comment;
        }
        else
        {
            catchToUpdate.Comment = new CommentDO { Text = comment };
        }

        LakeDO lakeDO = lakeService.GetLakeDO(lake);

        catchToUpdate.Media.Add(new MediaDO { MediaFormat = format, Image = new MediaDataDO { Length = image.Length, Data = image } });
        catchToUpdate.Lures = lureService.GetLureDO(lure.Id);
        catchToUpdate.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        catchToUpdate.Location = new LocationDO { Coordinates = coordinates, Lake = lakeDO };
        catchToUpdate.WeatherData = new WeatherDataDO { Temperature = waterTemperature, Weather = weather, MoonPosition = moonposition };
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

}
