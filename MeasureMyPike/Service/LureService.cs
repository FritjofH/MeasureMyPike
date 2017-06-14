using System;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;

namespace MeasureMyPike.Service
{
    public class LureService
    {
        public bool AddLure(String lureName, Brand brand)
        {
            Lures lure = new Lures
            {
                Name = lureName,
                Brand = brand,
                Catch = null
            };

            LureRepository dbconn = new LureRepository();

            return dbconn.AddLure(lure);
        }

        public Lures GetLure(int id)
        {
            LureRepository dbconn = new LureRepository();

            return dbconn.GetLure(id);
        }

        public Lures GetLure(string name)
        {
            LureRepository dbconn = new LureRepository();

            return dbconn.GetLure(name);
        }

        public bool DeleteLure(int id)
        {
            LureRepository dbconn = new LureRepository();
            return dbconn.DeleteLure(id);
        }

        public bool UpdateLure(int id, String name)
        {
            LureRepository dbconn = new LureRepository();

            return dbconn.UpdateLure(id, name);
        }
        

    }
}
