using System;

namespace MeasureMyPike.Application
{
    public class LureService
    {
        public void addLure(String name, Model.Brand brand)
        {
            Model.Lures lure = new Model.Lures();
            lure.Brand = brand;
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.addLure(name, brand);
        }

        public void updateLure(String id)
        {
            // lure.Brand.Name = name;
        }
    }
}
