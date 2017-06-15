using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class LureRepository
    {
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

        public List<LureDO> GetAllLures()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lureList = conn.Lure.ToList();

                    return lureList;
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

        public LureDO UpdateLure(int id, string lureName)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var lureToUpdate = conn.Lure.FirstOrDefault(it => it.Id == id);
                    lureToUpdate.Name = lureName;
                    conn.SaveChanges();

                    return lureToUpdate;
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