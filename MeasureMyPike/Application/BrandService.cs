namespace MeasureMyPike.Application
{
    public class BrandService
    {
        public void addBrand(string name)
        {
            Model.Brand brand = new Model.Brand
            {
                    Name = name
            };
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.addBrand(brand);
        }

        public Model.Brand getBrand(int id)
        {
            Model.Brand brand = new Model.Brand();
            brand.Id = id;
            DatabaseConnection dbconn = new DatabaseConnection();
            Model.Brand dd = dbconn.getBrand(brand);
            return dd;
        }
    }
}
