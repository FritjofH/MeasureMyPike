using System;

namespace MeasureMyPike.Application
{
    public class LureService
    {
        public bool addLure(String name, Model.Brand brand)
        {
            Model.Lures lure = new Model.Lures
            {
                Name = lureName,
                Brand = brand,
                Catch = null
            };

            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.addLure(lure);
        }

        /*
        public bool deleteLure(string id)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            return dbconn.deleteLure(id);
        }

        public void updateLure(String id)
        {
            // lure.Brand.Name = name;
        }
        */

    }
}
