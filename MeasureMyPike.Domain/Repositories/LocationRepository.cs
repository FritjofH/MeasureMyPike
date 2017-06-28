using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public class LocationRepository : ILocationRepository
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
        public bool UpdateLocation(int id, string lake, string coordinates)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var updatedLocation = conn.Location.FirstOrDefault(it => it.Id == id);
                    conn.Location.Attach(updatedLocation);
                    updatedLocation.Lake = lake;
                    updatedLocation.Coordinates = coordinates;
                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public bool DeleteLocation(LocationDO locationToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Location.Attach(locationToDelete);
                    conn.Location.Remove(locationToDelete);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}