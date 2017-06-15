using System.Collections.Generic;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service

{
    public class LocationService : ILocationService
    {

        public Location AddLocation(string lake, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var location = new LocationDO { Lake = lake, Coordinates = coordinates };
            var createdLocation = locationRepo.AddLocation(location);

            return ConvertToLocation(createdLocation);
        }

        public Location GetLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var location = locationRepo.GetLocation(id);

            return ConvertToLocation(location);
        }

        public LocationDO GetLocationDO(int id)
        {
            var locationRepo = new LocationRepository();
            var location = locationRepo.GetLocation(id);

            return location;
        }

        public Location UpdateLocation(int id, string name, string coordinates)
        {
            var locationRepo = new LocationRepository();
            var updatedLocation = locationRepo.UpdateLocation(id, name, coordinates);

            return ConvertToLocation(updatedLocation);
        }

        private Location ConvertToLocation(LocationDO locationToConvert)
        {
            return new Location
            {
                Coordinates = locationToConvert.Coordinates,
                Id = locationToConvert.Id,
                Lake = locationToConvert.Lake
            };
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