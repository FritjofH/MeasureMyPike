using MeasureMyPike.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeasureMyPike
{
    public class CatchRepository : ICatchRepository
    {
        public CatchDO AddCatch(CatchDO newCatch)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Lure.Attach(newCatch.Lures);
                    conn.Brand.Attach(newCatch.Lures.Brand);
                    conn.User.Attach(newCatch.User);
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public CatchDO GetCatch(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selectedCatch = conn.Catch.Include("Media").Include("Lures").Include("Location").Include("Comment").Include("Fish").Include("User").Include("WeatherData").Include("Statistics").FirstOrDefault(it => it.Id == id);
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
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public List<CatchDO> GetAllCatch()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var catchList = conn.Catch.Include("Media").Include("Lures").Include("Location").Include("Comment").Include("Fish").Include("User").Include("WeatherData").Include("Statistics").ToList();
                    return catchList;
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

        public bool UpdateCatch(int id, CatchDO changedCatch)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var catchToUpdate = conn.Catch.First(it => it.Id == changedCatch.Id);
                    conn.Catch.Attach(catchToUpdate);
                    catchToUpdate.Location = changedCatch.Location;
                    catchToUpdate.Lures = changedCatch.Lures;
                    catchToUpdate.Media = changedCatch.Media;
                    catchToUpdate.Timestamp = changedCatch.Timestamp;
                    catchToUpdate.WeatherData = changedCatch.WeatherData;
                    catchToUpdate.Comment = changedCatch.Comment;
                    catchToUpdate.Fish = changedCatch.Fish;
                    catchToUpdate.Statistics = changedCatch.Statistics;
                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
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

        public bool DeleteCatch(CatchDO catchToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Catch.Attach(catchToDelete);
                    conn.User.Attach(catchToDelete.User);
                    conn.Comment.Attach(catchToDelete.Comment);
                    conn.Fish.Attach(catchToDelete.Fish);
                    conn.Location.Attach(catchToDelete.Location);
                    conn.Lake.Attach(catchToDelete.Location.Lake);
                    conn.Lure.Attach(catchToDelete.Lures);
                    conn.WeatherData.Attach(catchToDelete.WeatherData);

                    while (catchToDelete.Media.Count > 0)
                    {
                        conn.Media.Attach(catchToDelete.Media.First());
                        conn.MediaData.Remove(catchToDelete.Media.First().Image);
                        conn.Media.Remove(catchToDelete.Media.First());
                    }

                    conn.Location.Remove(catchToDelete.Location);
                    conn.WeatherData.Remove(catchToDelete.WeatherData);
                    conn.Fish.Remove(catchToDelete.Fish);
                    conn.Comment.Remove(catchToDelete.Comment);
                    conn.Catch.Remove(catchToDelete);

                    conn.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
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
