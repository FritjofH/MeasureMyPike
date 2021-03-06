﻿using MeasureMyPike.Application.Common;
using System.Collections.Generic;
using MeasureMyPike.Repo;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service

{
    public class LocationService : ILocationService
    {
        public Location GetLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionUtil();
            var location = locationRepo.GetLocation(id);

            return conversionService.ConvertToLocation(location);
        }

        public LocationDO GetLocationDO(int id)
        {
            var locationRepo = new LocationRepository();
            var location = locationRepo.GetLocation(id);

            return location;
        }

        public List<Location> GetAllLocations()
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionUtil();
            var locationList = new List<Location>();

            foreach (var location in locationRepo.GetAllLocations())
            {
                locationList.Add(conversionService.ConvertToLocation(location));
            }

            return locationList;
        }

        public bool UpdateLocation(int id, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionUtil();
            return locationRepo.UpdateLocation(id, coordinates);
        }

        public bool DeleteLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var locationToDelete = GetLocationDO(id);
            var deleted = locationRepo.DeleteLocation(locationToDelete);

            return deleted;
        }
    }
}