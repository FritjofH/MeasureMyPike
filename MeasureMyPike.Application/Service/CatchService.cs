using MeasureMyPike;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;
using MeasureMyPike.Application.Common;

public class CatchService : ICatchService
{
    public Catch AddCatch(NewCatch newCatch)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();
        var lakeService = new LakeService();
        var locationService = new LocationService();
        var mediaList = new List<MediaDO>();
        var conversionService = new ConversionUtil();
        var userService = new UserService();
        string moonposition = MoonUtil.Phase(DateTime.Parse(newCatch.date)); 

        mediaList.Add(new MediaDO
        {
            MediaFormat = "",
            Image = new MediaDataDO
            {
                Length = mediaData.Length,
                Data = mediaData
            }
        });

        LakeDO lakeDO = lakeService.GetLakeDO(lakeName);

        var newCatchDo = new CatchDO
        {
            User = userService.GetUserDO(username),
            Comment = new CommentDO { Text = comment },
            Media = mediaList,
            Lure = lureService.GetLureDO(lure.Id),
            Fish = new FishDO { Length = fishLength, Weight = fishWeight },
            Location = new LocationDO { Lake = lakeDO, Coordinates = coordinates },
            WeatherData = new WeatherDataDO { WaterTemperature = waterTemperature, AirTemperature = airTemperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = timeStamp
        };

        var createdCatch = catchRepo.AddCatch(newCatchDO);

        return conversionService.ConvertToCatch(createdCatch);
    }

    public Catch GetCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);
        var conversionService = new ConversionUtil();

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
        var conversionService = new ConversionUtil();

        foreach (var catchDO in catchRepo.GetAllCatches())
        {
            catchList.Add(conversionService.ConvertToCatch(catchDO));
        }

        return catchList;
    }

    // TODO: Här borde vi tänka om.
    // När man bara ska ändra tex kommentaren så ska den väl inte skapa en ny MediaDO, ny FishDO, ny LocationDO och ny WeatherDO utan bara ändra det som är icke null tex.???
    //
    public bool UpdateCatch(int id, byte[] image, string format, DateTime timeStamp, string comment, Lure lure, int fishWeight, int fishLength, string lake, string coordinates, Double waterTemperature, Double airTemperature, string weather, string username, params string[] additionalInformation)
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
        catchToUpdate.Lure = lureService.GetLureDO(lure.Id);
        catchToUpdate.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        catchToUpdate.Location = new LocationDO { Coordinates = coordinates, Lake = lakeDO };
        catchToUpdate.WeatherData = new WeatherDataDO { WaterTemperature = waterTemperature, AirTemperature = airTemperature, Weather = weather, MoonPosition = moonposition };
        catchToUpdate.Timestamp = timeStamp;

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
