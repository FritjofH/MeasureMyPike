using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike.Repo
{
    public interface IBrandRepository
    {
        BrandDO AddBrand(BrandDO newBrand);
        bool DeleteBrand(int brandToDelete);
        List<BrandDO> GetAllBrands();
        BrandDO GetBrand(int id);
        BrandDO UpdateBrand(BrandDO changedBrand);
    }
}