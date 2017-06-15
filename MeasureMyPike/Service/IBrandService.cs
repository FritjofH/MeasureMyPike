using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Service
{
    public interface IBrandService
    {
        Brand AddBrand(string name);
        bool DeleteBrand(int id);
        List<Brand> GetAllBrands();
        Brand GetBrand(int id);
        BrandDO GetBrandDO(int id);
        Brand UpdateBrand(int id, string newName);
    }
}