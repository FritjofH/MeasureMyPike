using MeasureMyPike.Models;
using System.Collections;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public class BrandService
    {
        public void AddBrand(string name)
        {
            Brand brand = new Brand { Name = name };
            DatabaseConnection dbconn = new DatabaseConnection();
            // är Id automatiskt tilldelat då??
            dbconn.addBrand(brand);
        }

        public void AddBrand(Brand brand)
        {
           
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.addBrand(brand);
        }

        public Brand getBrand(int id)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.getBrand(id);
        }

        public Brand getBrand(string name)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.getBrand(name);
        }

        public List<Brand> getAllBrand()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            var z = dbconn.getAllBrands();
           
            return z;
        }

        public void setBrand(int id, string name)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.updateBrand(id, name);
        }

        public void setBrand(int id, Brand brand)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.updateBrand(id, brand.Name);
        }
    }
}
