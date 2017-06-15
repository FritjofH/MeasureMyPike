﻿using System.Collections.Generic;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service

{
    public class LocationService
    {

        public Location AddLocation(string lake, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var location = new LocationDO { Lake = lake, Coordinates = coordinates };
            var createdLocation = locationRepo.AddLocation(location);
          
            return convertToLocation(createdLocation);
        }

        public Location GetLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var l = locationRepo.GetLocation(id);

            return convertToLocation(l);
        }
    public Location AddLocation(Location location)
    {
        LocationDO locationDo = new LocationDO
        {
            Lake = location.Lake,
            Coordinates = location.Coordinates
        };

        LocationRepository dbconn = new LocationRepository();

        var locationDO = dbconn.AddLocation(locationDo);

        private Location convertLocation(LocationDO locationDO)
        {
            var locationREpo = new LocationRepository();
            var locationList = new List<Location>();

            foreach(var location in locationREpo.GetAllLocations())
            {
                locationList.Add(convertToLocation(location));
            }

            return locationList;
        }

        public Location UpdateLocation(int id, string name, string coordinates)
        {
            var locationRepo = new LocationRepository();

            var updatedLocation = locationRepo.UpdateLocation(id, name, coordinates);

            return convertToLocation(updatedLocation);
        }

        private Location convertToLocation(LocationDO locationToConvert)
        {
            return new Location {
                Coordinates = locationToConvert.Coordinates,
                Id = locationToConvert.Id,
                Lake = locationToConvert.Lake
            };
        }
            public bool SetLocation(int id, String name, String coordinates)
            {
                LocationRepository dbconn = new LocationRepository();

                return dbconn.UpdateLocation(id, name, coordinates);
            }

            public bool DeleteLocation(int id)
        {
            LocationRepository dbconn = new LocationRepository();

            return dbconn.DeleteLocation(id);
        }


    }
}