using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Repo
{
    public class LureRepository
    {
        public List<LureDO> GetLures()
        {

            try
            {
                using (var conn = new ModelContainer())
                {
                    var l = conn.Lure.ToList();
                    return l;
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

        public LureDO GetLure(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedLure = conn.Lure.FirstOrDefault(it => it.Id == id);
                    {
                        if (selectedLure != null)
                        {
                            return selectedLure;
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

        public bool UpdateLure(int id, string lureName)
        {
            try
            {
                using (var conn = new ModelContainer())
                {

                    var lureToUpdate = conn.Lure.FirstOrDefault(it => it.Id == id);
                    lureToUpdate.Name = lureName;
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
        public LureDO AddLure(LureDO newLure)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdLure = conn.Lure.Add(newLure);
                    conn.SaveChanges();
                    return createdLure;
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


        public bool DeleteLure(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lure = GetLure(id);
                    if (lure != null)
                    {
                        conn.Lure.Remove(lure);
                        conn.SaveChanges();
                        return true;
                    }
                    return false;
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

    }
}