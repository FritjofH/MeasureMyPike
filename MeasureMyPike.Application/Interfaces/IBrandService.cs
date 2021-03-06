﻿using System.Collections.Generic;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public interface IBrandService
    {
        Brand AddBrand(string name);
        bool DeleteBrand(int id);
        List<Brand> GetAllBrands();
        Brand GetBrand(int id);
        BrandDO GetBrandDO(int id);
        bool UpdateBrand(int id, string newName);
    }
}