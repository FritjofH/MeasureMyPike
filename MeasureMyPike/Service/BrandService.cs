using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public class BrandService
    {
        public Brand AddBrand(string name)
        {
            Brand brand = new Brand { Name = name };
            BrandRepository dbconn = new BrandRepository();
            // är Id automatiskt tilldelat då??
            return dbconn.AddBrand(brand);
        }

        public Brand AddBrand(Brand brand)
        {
            BrandRepository dbconn = new BrandRepository();
            return dbconn.AddBrand(brand);
        }

        public Brand GetBrand(int id)
        {
            BrandRepository dbconn = new BrandRepository();
            return dbconn.GetBrand(id);
        }

        public Brand GetBrand(string name)
        {
            BrandRepository dbconn = new BrandRepository();
            return dbconn.GetBrand(name);
        }

        public List<Models.Application.Brand> GetAllBrand()
        {
            BrandRepository dbconn = new BrandRepository();
           
            return dbconn.GetAllBrands();
        }

        public Brand SetBrand(int id, string name)
        {
            BrandRepository dbconn = new BrandRepository();
            return dbconn.UpdateBrand(id, name);
        }

    }
}
