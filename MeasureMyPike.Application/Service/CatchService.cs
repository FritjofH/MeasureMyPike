﻿using MeasureMyPike;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;

public class CatchService : ICatchService
{
    public Catch CreateCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, string username)
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
            User = userService.GetUserDO("hostf"),
            Comment = new CommentDO { Text = comment },
            Media = mediaList,
            Lures = lureService.GetLureDO(lure.id),
            Fish = new FishDO { Length = fishLength, Weight = fishWeight },
            Location = new LocationDO { Lake = lake, Coordinates = coordinates },
            WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition },
            Timestamp = DateTime.Now    // TODO: kanske skicka med istället = fångades
        };

        var createdCatch = catchRepo.AddCatch(newCatch);

        return conversionService.convertToCatch(createdCatch);
    }

    public Catch GetCatch(int id)
    {
        var catchRepo = new CatchRepository();
        var selectedCatch = catchRepo.GetCatch(id);
        var conversionService = new ConversionService();

        return conversionService.convertToCatch(selectedCatch);
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
            catchList.Add(conversionService.convertToCatch(catchDO));
        }

        return catchList;
    }

    public bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username)
    {
        var catchRepo = new CatchRepository();
        var lureService = new LureService();

        var catchToUpdate = catchRepo.GetCatch(id);
        catchToUpdate.Comment = new CommentDO { Text = comment };
        catchToUpdate.Media.Add(new MediaDO { MediaFormat = format, Image = new MediaDataDO { Length = image.Length, Data = image } });
        catchToUpdate.Lures = lureService.GetLureDO(lure.id);
        catchToUpdate.Fish = new FishDO { Length = fishLength, Weight = fishWeight };
        catchToUpdate.Location = new LocationDO { Lake = lake, Coordinates = coordinates };
        catchToUpdate.WeatherData = new WeatherDataDO { Temperature = temperature, Weather = weather, MoonPosition = moonposition };
        catchToUpdate.Timestamp = DateTime.Now; // TODO: kanske skicka med istället

        var updatedCatch = catchRepo.UpdateCatch(id, catchToUpdate);

        return updatedCatch;
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

        foreach (var media in catchToConvert.Media)
        {
            mediaList.Add(media.Id);
        }

        var catchToReturn = new Catch
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

        return catchToReturn;
    }
}
