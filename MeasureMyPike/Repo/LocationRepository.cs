using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class LocationRepository
    {

        public Location GetLocation(int id)
        {            
            using (var conn = new ModelContainer())
            {
                Location cc = conn.Location.FirstOrDefault(it => it.Id == id);
                {
                    if (cc != null)
                    {
                        return cc;
                    }
                    else return null;
                }
            }
        }

        public Location AddLocation(Location cc)
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

        public List<Location> GetAllLocations()
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
                    Location o = conn.Location.FirstOrDefault(it => it.Id == id);
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


    }
}