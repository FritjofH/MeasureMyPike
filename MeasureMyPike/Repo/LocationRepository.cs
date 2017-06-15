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
            using (var conn = new ModelContainer())
            {
                LocationDO cc = conn.Location.FirstOrDefault(it => it.Id == id);
                {
                    if (cc != null)
                    {
                        return cc;
                    }
                    else return null;
                }
            }
        }

        public LocationDO AddLocation(LocationDO cc)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var c = conn.Location.Add(cc);
                    conn.SaveChanges();
                    return c;
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
                    var value = conn.Location.ToList();
                    return value;
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
        public bool UpdateLocation(int id, string locationName, String coordinates)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    LocationDO o = conn.Location.FirstOrDefault(it => it.Id == id);
                    o.Lake = locationName;
                    o.Coordinates = coordinates;
                    conn.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // TODO: better handling
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteLocation(int id)
        {
            using (var conn = new ModelContainer())
            {
                LocationDO location = GetLocation(id);
                if (location != null)
                {
                    conn.Location.Remove(location);
                    conn.SaveChanges();
                    return true;
                }
                return false;
            }
        }


    }
}