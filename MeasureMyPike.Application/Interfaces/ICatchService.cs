using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System;

public interface ICatchService
{
    Catch AddCatch(NewCatch newCatch);
    bool DeleteCatch(int id);
    List<Catch> GetAllCatches();
    Catch GetCatch(int id);
    CatchDO GetCatchDO(int id);
    bool UpdateCatch(int id, byte[] image, string format, DateTime timeStamp, string comment, Lure lure, int fishWeight, int fishLength, string lake, string coordinates, Double waterTemperature, Double airTemperature, string weather, string username, params string[] additionalInformation);
}