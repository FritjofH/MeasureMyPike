﻿using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public interface ILureService
    {
        Lure AddLure(string lureName, int brandId, int weight, string colour);
        bool DeleteLure(int id);
        Lure GetLure(int id);
        LureDO GetLureDO(int id);
        bool UpdateLure(int id, int brandId, string name, int weight, string colour);
        List<Lure> GetAllLures();
    }
}