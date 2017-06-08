using MeasureMyPike.Model;

namespace MeasureMyPike.Application
{
    public class BrandService
    {
        public void addBrand(string name)
        {
            Brand brand = new Brand
            {
                Name = name
            };
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
    }
}
