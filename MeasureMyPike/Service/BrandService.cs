using MeasureMyPike.Models;
using System.Collections;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public class BrandService
    {
        public void AddBrand(string name)
        {
            Brand brand = new Brand
            {
                Name = name
            };
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.addBrand(brand);
        }
        public void AddBrand(Brand brand)
        {
           
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.addBrand(brand);
        }


        public Brand getBrand(int id)
        {
            Brand brand = new Brand();
            brand.Id = id;
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.getBrand(brand);
        }

        public List<Brand> getAllBrand()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            var z = dbconn.getAllBrands();
           
            return z;
        }

        public Brand getBrand(string id)
        {
            Brand brand = new Brand();
            brand.Name = id;
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.getBrand(brand);
        }
    }
}
