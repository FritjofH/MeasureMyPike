using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeasureMyPike
{
    public class CatchRepository
    {

        public CatchDO AddCatch(CatchDO cc)
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
        public List<CatchDO> GetAllCatch()
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

        public CatchDO GetCatch(int id)
        {
            using (var conn = new ModelContainer())
            {
                var selectedCatch = conn.Catch.FirstOrDefault(it => it.Id == id);
                {
                    if (selectedCatch != null)
                    {
                        return selectedCatch;
                    }
                    else return null;
                }
            }
        }

        public bool UpdateCatch(int id, CatchDO cc)
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
                var c = GetCatch(id);
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
