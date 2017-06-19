using System.Collections.Generic;
using MeasureMyPike.Repo;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service

{
    public class LocationService : ILocationService
    {

        public Location AddLocation(string lake, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionService();
            var location = new LocationDO { Lake = lake, Coordinates = coordinates };
            var createdLocation = locationRepo.AddLocation(location);

            return conversionService.ConvertToLocation(createdLocation);
        }

        public Location GetLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionService();
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
            var conversionService = new ConversionService();
            var locationList = new List<Location>();

            foreach (var location in locationRepo.GetAllLocations())
            {
                locationList.Add(conversionService.ConvertToLocation(location));
            }

            return locationList;
        }

        public Location UpdateLocation(int id, string name, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var conversionService = new ConversionService();
            var updatedLocation = locationRepo.UpdateLocation(id, name, coordinates);

            return conversionService.ConvertToLocation(updatedLocation);
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