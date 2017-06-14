using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Entity_Framework;


namespace MeasureMyPike.Service
{
    public class LocationService
    {

        public Location AddLocation(String lake, String coordinates)
        {
            Location location = new Location
            {                
                Lake = lake,
                Coordinates = coordinates                
            };

            LocationRepository dbconn = new LocationRepository();

            return dbconn.AddLocation(location);
        }

        public Location GetLocation(int id)
        {
            LocationRepository dbconn = new LocationRepository();
            return dbconn.GetLocation(id);
        }

        public List<Location> GetAllLocations()
        {
            LocationRepository dbconn = new LocationRepository();
            return dbconn.GetAllLocations();
        }

        public bool UpdateLocation(int id, String name, String coordinates)
        {
            LocationRepository dbconn = new LocationRepository();

            return dbconn.UpdateLocation(id, name, coordinates);
        }


    }
}