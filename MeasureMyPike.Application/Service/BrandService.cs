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
            
            var newBrand = new BrandDO { Name = name };
            var conversionService = new ConversionService();
            var savedBrand = iBrandRepository.AddBrand(newBrand);

            return conversionService.ConvertToBrand(savedBrand);
        }

        public Brand GetBrand(int id)
        {
            var conversionService = new ConversionService();
            var selectedBrand = iBrandRepository.GetBrand(id);

            return conversionService.ConvertToBrand(selectedBrand);
        }

        public BrandDO GetBrandDO(int id)
        {
            var selectedBrand = iBrandRepository.GetBrand(id);

            return selectedBrand;
        }

        public List<Brand> GetAllBrands()
        {
            var conversionService = new ConversionService();
            var brandList = new List<Brand>();
            var brands = iBrandRepository.GetAllBrands();

            foreach (var brand in brands)
            {
                brandList.Add(conversionService.ConvertToBrand(brand));
            }
            
            return brandList;
        }

        public Brand UpdateBrand(int id, string newName)
        {
            var conversionService = new ConversionService();
            var brandToUpdate = GetBrandDO(id);
            brandToUpdate.Name = newName;
            var updatedBrand = iBrandRepository.UpdateBrand(brandToUpdate);

            return conversionService.ConvertToBrand(updatedBrand);
        }

        public bool DeleteBrand(int id)
        {
            var brandToDelete = iBrandRepository.GetBrand(id);
            var deleted = iBrandRepository.DeleteBrand(brandToDelete);
            return (bool)deleted;
        }

    }
}
