﻿using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;

public interface ICatchService
{
    Catch CreateCatch(byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, string username);
    bool DeleteCatch(int id);
    List<Catch> GetAllCatches();
    Catch GetCatch(int id);
    CatchDO GetCatchDO(int id);
    bool UpdateCatch(int id, byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, Brand brand, string username);
}