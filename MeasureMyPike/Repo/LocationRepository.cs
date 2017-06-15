using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class LocationRepository
    {

        public LocationDO GetLocation(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedLocation = conn.Location.FirstOrDefault(it => it.Id == id);
                    {
                        if (selectedLocation != null)
                        {
                            return selectedLocation;
                        }
                        else return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public LocationDO AddLocation(LocationDO newLocation)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdLocation = conn.Location.Add(newLocation);
                    conn.SaveChanges();
                    return createdLocation;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<LocationDO> GetAllLocations()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var locationList = conn.Location.ToList();

                    return locationList;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public LocationDO UpdateLocation(int id, string lake, string coordinates)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var updatedLocation = conn.Location.FirstOrDefault(it => it.Id == id);
                    updatedLocation.Lake = lake;
                    updatedLocation.Coordinates = coordinates;
                    conn.SaveChanges();

                    return updatedLocation;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}