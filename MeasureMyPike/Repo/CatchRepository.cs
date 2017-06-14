using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeasureMyPike
{
    public class CatchRepository
    {

        public Catch AddCatch(Catch cc)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var c = conn.Catch.Add(cc);
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
        public List<Catch> GetAllCatch()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var value = conn.Catch.ToList();
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

        public Catch GetCatch(int id)
        {
            using (var conn = new ModelContainer())
            {
                Catch cc = conn.Catch.FirstOrDefault(it => it.Id == id);
                {
                    if (cc != null)
                    {
                        return cc;
                    }
                    else return null;
                }
            }
        }

        public bool UpdateCatch(int id, Catch cc)
        {
            try
            {
                if (!DeleteCatch(id))
                {
                    // specified id was probably not found
                    return false;
                }
                using (var conn = new ModelContainer())
                {
                    // add new with same id
                    cc.Id = id;
                    conn.Catch.Add(cc);
                    conn.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteCatch(int id)
        {
            using (var conn = new ModelContainer())
            {
                Catch c = GetCatch(id);
                if (c != null)
                {
                    conn.Catch.Remove(c);
                    conn.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
