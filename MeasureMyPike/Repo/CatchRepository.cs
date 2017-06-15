using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeasureMyPike
{
    public class CatchRepository
    {
        public CatchDO AddCatch(CatchDO newCatch)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var createdCatch = conn.Catch.Add(newCatch);
                    conn.SaveChanges();

                    return createdCatch;
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
            try
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
                    var catchList = conn.Catch.ToList();
                    return catchList;
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

        public bool UpdateCatch(int id, CatchDO changedCatch)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var catchToUpdate = conn.Catch.First(it => it.Id == changedCatch.Id);
                    catchToUpdate.Location = changedCatch.Location;
                    catchToUpdate.Lures = changedCatch.Lures;
                    catchToUpdate.Media = changedCatch.Media;
                    catchToUpdate.Timestamp = changedCatch.Timestamp;
                    catchToUpdate.WeatherData = changedCatch.WeatherData;
                    catchToUpdate.Comment = changedCatch.Comment;
                    catchToUpdate.Fish = changedCatch.Fish;
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
            try
            {
                using (var conn = new ModelContainer())
                {
                    var catchToDelete = GetCatch(id);
                    if (catchToDelete != null)
                    {
                        conn.Catch.Remove(catchToDelete);
                        conn.SaveChanges();

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        }
}
