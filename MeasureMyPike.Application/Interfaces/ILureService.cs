﻿using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Service
{
    public interface ILureService
    {
        Lure AddLure(string lureName, Brand brand);
        bool DeleteLure(int id);
        Lure GetLure(int id);
        LureDO GetLureDO(int id);
        Lure UpdateLure(int id, string name);
    }
}