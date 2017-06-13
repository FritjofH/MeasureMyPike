using System;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Service
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

        //public Lures getFirstLure()
        //{
        //    DatabaseConnection dbconn = new DatabaseConnection();

        //    return dbconn.getFirstLure();
        //}

        public Lures getLure(int id)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.getLure(id);
        }

        public Lures getLure(string id)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.getLure(id);
        }


      /*  public bool deleteLure(string id)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            //return dbconn.deleteLure(id);
        }
        */
        public bool updateLure(int id, String name)
        {
            DatabaseConnection dbconn = new DatabaseConnection();

            return dbconn.updateLure(id, name);
        }
        

    }
}
