using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Repo;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public class BrandService : IBrandService
    {
        private IBrandRepository iBrandRepository;
            public BrandService() {
            iBrandRepository = new BrandRepository();
        }
        public Brand AddBrand(string name)
        {
            //var brandRepo = new BrandRepository();
            var newBrand = new BrandDO { Name = name };
            var conversionService = new ConversionService();
            var savedBrand = iBrandRepository.AddBrand(newBrand);

            return conversionService.ConvertToBrand(savedBrand);
        }

        public Brand GetBrand(int id)
        {
            //var brandRepo = new BrandRepository();
            var conversionService = new ConversionService();
            var selectedBrand = iBrandRepository.GetBrand(id);

            return conversionService.ConvertToBrand(selectedBrand);
        }

        public BrandDO GetBrandDO(int id)
        {
            //var brandRepo = new BrandRepository();
            var selectedBrand = iBrandRepository.GetBrand(id);

            return selectedBrand;
        }

        public List<Brand> GetAllBrands()
        {
            //var brandRepo = new BrandRepository();
            var conversionService = new ConversionService();
            var brandList = new List<Brand>();
            var brands = iBrandRepository.GetAllBrands();

            foreach (var brand in brands)
            {
                brandList.Add(conversionService.ConvertToBrand(brand));
            }

            //var barandList = new List<Brand>();
            //barandList.Add(new Brand
            //{
            //    Id = 0,
            //    Name = "Muppet"
            //});

            //return barandList;

            return brandList;
        }

        public Brand UpdateBrand(int id, string newName)
        {
            //var brandRepo = new BrandRepository();
            var conversionService = new ConversionService();
            var brandToUpdate = GetBrandDO(id);
            var updatedBrand = iBrandRepository.UpdateBrand(brandToUpdate);

            return conversionService.ConvertToBrand(updatedBrand);
        }

        public bool DeleteBrand(int id)
        {
            //var brandRepo = new BrandRepository();
            var brandToDelete = GetBrandDO(id);

            var deleted = iBrandRepository.DeleteBrand(brandToDelete);

            return (bool)deleted;
        }

    }
}
