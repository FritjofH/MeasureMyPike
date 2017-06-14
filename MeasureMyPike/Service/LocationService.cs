using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public class LocationService
    {

        public Location AddLocation(String lake, String coordinates)
        {
            LocationDO location = new LocationDO
            {                
                Lake = lake,
                Coordinates = coordinates                
            };

            LocationRepository dbconn = new LocationRepository();

             var locationDO = dbconn.AddLocation(location);
          
            return convertLocation(locationDO);
        }

        private Location convertLocation(LocationDO locationDO)
        {
            Location l = new Location();
            l.Id = locationDO.Id;
            l.Lake = locationDO.Lake;
            l.Coordinates = locationDO.Coordinates;
            return l;
            
        }
        private List<Location> convertLocationList(List<LocationDO> locationDO)
        {
            List<Location> locationList = new List<Location>();
            foreach (LocationDO ldo in locationDO) {
                Location l = new Location();
                l.Id = ldo.Id;
                l.Lake = ldo.Lake;
                l.Coordinates = ldo.Coordinates;
                locationList.Add(l);
             }
            return locationList;

        }

        public Location GetLocation(int id)
        {
            LocationRepository dbconn = new LocationRepository();
            var l = dbconn.GetLocation(id);
            return convertLocation(l);
        }

        public List<Location> GetAllLocations()
        {
            LocationRepository dbconn = new LocationRepository();
            List<LocationDO> locationdoList = dbconn.GetAllLocations();
            return convertLocationList(locationdoList);
        }

        public bool UpdateLocation(int id, String name, String coordinates)
        {
            LocationRepository dbconn = new LocationRepository();

            return dbconn.UpdateLocation(id, name, coordinates);
        }


    }
}