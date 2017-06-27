using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike.Repo
{
    public interface IBrandRepository
    {
        BrandDO AddBrand(BrandDO newBrand);
        bool DeleteBrand(BrandDO brandToDelete);
        List<BrandDO> GetAllBrands();
        BrandDO GetBrand(int id);
        bool UpdateBrand(BrandDO changedBrand);
    }
}