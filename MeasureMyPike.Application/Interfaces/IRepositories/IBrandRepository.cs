using System.Collections.Generic;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public interface IBrandRepository
    {
        BrandDO AddBrand(BrandDO newBrand);
        bool DeleteBrand(BrandDO brandToDelete);
        List<BrandDO> GetAllBrands();
        BrandDO GetBrand(int id);
        BrandDO UpdateBrand(BrandDO changedBrand);
    }
}