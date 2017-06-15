using System.Collections.Generic;
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

            return ConvertToLocation(createdLocation);
        }

        public Location GetLocation(int id)
        {
            var locationRepo = new LocationRepository();
            var location = locationRepo.GetLocation(id);

            return ConvertToLocation(location);
        }
        public List<Location> AddLocation(Location location)
        {
            var locationDo = new LocationDO
            {
                Lake = location.Lake,
                Coordinates = location.Coordinates
            };

            var locationRepo = new LocationRepository();

            var locationDO = locationRepo.AddLocation(locationDo);
            return ConvertLocation(locationDO);
        }
            private List<Location> ConvertLocation(LocationDO locationDO)
            {
                var locationREpo = new LocationRepository();
                var locationList = new List<Location>();

                foreach (var location in locationREpo.GetAllLocations())
                {
                    locationList.Add(ConvertToLocation(location));
                }

                return locationList;
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

                return locationRepo.DeleteLocation(id);
            }
            public Location SetLocation(int id, string name, string coordinates)
            {
                var locationRepo = new LocationRepository();

                return ConvertToLocation(locationRepo.UpdateLocation(id, name, coordinates));
            }        
        }
    }