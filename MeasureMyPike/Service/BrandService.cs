using MeasureMyPike.Models.Entity_Framework;
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
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.getBrand(id);
        }

        public List<Models.Application.Brand> getAllBrand()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
           
            return dbconn.getAllBrands();
        }
    }
}
