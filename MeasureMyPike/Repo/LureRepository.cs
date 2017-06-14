using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class LureRepository
    {
        public List<Lures> GetLures()
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    var l = conn.Lures.ToList();
                    return l;
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

        public Lures GetLure(int id)
        {
            using (var conn = new ModelContainer())
            {
                Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public Lures GetLure(string name)
        {
            using (var conn = new ModelContainer())
            {
                Lures o = conn.Lures.FirstOrDefault(it => it.Name == name);
                {
                    if (o != null)
                    {
                        return o;
                    }
                    else return null;
                }
            }
        }

        public bool UpdateLure(int id, string lureName)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Lures o = conn.Lures.FirstOrDefault(it => it.Id == id);
                    o.Name = lureName;
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
        public bool AddLure(Lures lure)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Lures.Add(lure);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // TODO: better handling
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        public bool DeleteLure(int id)
        {
            using (var conn = new ModelContainer())
            {
                Lures lure = GetLure(id);
                if (lure != null)
                {
                    conn.Lures.Remove(lure);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }

    }
}