using System;
using MeasureMyPike.Model;

namespace MeasureMyPike.Application
{
    public class LureService
    {
        public bool addLure(String lureName, Brand brand)
        {
            Lures lure = new Lures
            {
                Name = lureName,
                Brand = brand,
                Catch = null
            };

            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.addLure(lure);
        }

        public Lures getFirstLure()
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.getFirstLure();
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
