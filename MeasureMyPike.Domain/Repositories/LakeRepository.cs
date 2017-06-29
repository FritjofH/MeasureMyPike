using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public class LakeRepository : ILakeRepository
    {
        public LakeDO GetLake(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selected = conn.Lake.FirstOrDefault(it => it.Id == id);
                    {
                        if (selected != null)
                        {
                            return selected;
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
        public LakeDO GetLake(string name)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selected = conn.Lake.FirstOrDefault(it => it.Name == name);
                    {
                        if (selected != null)
                        {
                            return selected;
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

        public LakeDO AddLake(LakeDO newLake)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var created = conn.Lake.Add(newLake);
                    conn.SaveChanges();
                    return created;
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

        public List<LakeDO> GetAllLakes()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var list = conn.Lake.ToList();

                    return list;
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
        public bool UpdateLake(int id, string name)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var updated = conn.Lake.FirstOrDefault(it => it.Id == id);
                    conn.Lake.Attach(updated);
                    updated.Name = name;
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

        public bool DeleteLake(LakeDO lakeToDelete)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Lake.Attach(lakeToDelete);
                    conn.Lake.Remove(lakeToDelete);
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