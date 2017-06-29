using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

public interface ICatchService
{
    Catch AddCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int waterTemperature, string weather, string username, params string[] additionalInformation);
    bool DeleteCatch(int id);
    List<Catch> GetAllCatches();
    Catch GetCatch(int id);
    CatchDO GetCatchDO(int id);
    bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int waterTemperature, string weather, string username, params string[] additionalInformation);
}