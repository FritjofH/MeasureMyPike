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
            var dbconn = new BrandRepository();
            var newBrand = new BrandDO { Name = name };
            var savedBrand = dbconn.AddBrand(newBrand);

            return ConvertToBrand(savedBrand);
        }

        public Brand GetBrand(int id)
        {
            var dbconn = new BrandRepository();
            var selectedBrand = dbconn.GetBrand(id);

            return ConvertToBrand(selectedBrand);
        }

        public List<Brand> GetAllBrands()
        {
            var dbconn = new BrandRepository();
            var brandList = new List<Brand>();
            var brands = dbconn.GetAllBrands();

            foreach (var brand in brands)
            {
                brandList.Add(ConvertToBrand(brand));
            }

            return brandList;
        }

        public Brand UpdateBrand(int id, string name)
        {
            var dbconn = new BrandRepository();
            var updatedBrand = dbconn.UpdateBrand(id, name);

            return ConvertToBrand(updatedBrand);
        }

        public bool DeleteBrand(int id)
        {
            var dbconn = new BrandRepository();
            var removed = dbconn.DeleteBrand(id);

            return (bool)removed;
        }

        private Brand ConvertToBrand(BrandDO brandToConvert)
        {
            return new Brand { Id = brandToConvert.Id, Name = brandToConvert.Name };
        }

    }
}
