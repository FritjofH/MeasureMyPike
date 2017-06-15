using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public class BrandService
    {
        public Brand AddBrand(string name)
        {
            var brandRepo = new BrandRepository();
            var newBrand = new BrandDO { Name = name };
            var savedBrand = brandRepo.AddBrand(newBrand);
            var conversionService = new ConversionService();

            return conversionService.ConvertToBrand(savedBrand);
        }

        public Brand GetBrand(int id)
        {
            var brandRepo = new BrandRepository();
            var selectedBrand = brandRepo.GetBrand(id);
            var conversionService = new ConversionService();

            return conversionService.ConvertToBrand(selectedBrand);
        }

        public BrandDO GetBrandDO(int id)
        {
            var brandRepo = new BrandRepository();
            var selectedBrand = brandRepo.GetBrand(id);

            return selectedBrand;
        }

        public List<Brand> GetAllBrands()
        {
            var brandRepo = new BrandRepository();
            var brandList = new List<Brand>();
            var brands = brandRepo.GetAllBrands();
            var conversionService = new ConversionService();

            foreach (var brand in brands)
            {
                brandList.Add(conversionService.ConvertToBrand(brand));
            }

            return brandList;
        }

        public Brand UpdateBrand(int id, string newName)
        {
            var brandRepo = new BrandRepository();
            var brandToUpdate = GetBrandDO(id);
            var updatedBrand = brandRepo.UpdateBrand(brandToUpdate);
            var cs = new ConversionService();

            return cs.ConvertToBrand(updatedBrand);
        }

        public bool DeleteBrand(int id)
        {
            var brandRepo = new BrandRepository();
            var brandToDelete = GetBrandDO(id);
            var deleted = brandRepo.DeleteBrand(brandToDelete);

            return (bool)deleted;
        }

    }
}
