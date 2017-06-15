using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System.Collections.Generic;
using System;

namespace MeasureMyPike.Service
{
    public class BrandService
    {
        public Brand AddBrand(string name)
        {
            var brandRepo = new BrandRepository();
            var newBrand = new BrandDO { Name = name };
            var savedBrand = brandRepo.AddBrand(newBrand);

            return ConvertToBrand(savedBrand);
        }

        public Brand GetBrand(int id)
        {
            var brandRepo = new BrandRepository();
            var selectedBrand = brandRepo.GetBrand(id);

            return ConvertToBrand(selectedBrand);
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

            foreach (var brand in brands)
            {
                brandList.Add(ConvertToBrand(brand));
            }

            return brandList;
        }

        public Brand UpdateBrand(int id)
        {
            var brandRepo = new BrandRepository();
            var brandToUpdate = GetBrandDO(id);
            var updatedBrand = brandRepo.UpdateBrand(brandToUpdate);

            return ConvertToBrand(updatedBrand);
        }

        public bool DeleteBrand(int id)
        {
            var brandRepo = new BrandRepository();
            var deleted = brandRepo.DeleteBrand(id);

            return (bool)deleted;
        }

        private Brand ConvertToBrand(BrandDO brandToConvert)
        {
            return new Brand { Id = brandToConvert.Id, Name = brandToConvert.Name };
        }

    }
}
