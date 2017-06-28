using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public class BrandRepository : IBrandRepository
    {

        public BrandDO AddBrand(BrandDO newBrand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var created = conn.Brand.Add(newBrand);
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

        public BrandDO GetBrand(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var selected = conn.Brand.First(u => u.Id == id);

                    return selected;
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

        public List<BrandDO> GetAllBrands()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var result = conn.Brand.ToList();

                    return result;
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

        public bool UpdateBrand(BrandDO changedBrand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brandToUpdate = conn.Brand.FirstOrDefault(it => it.Id == changedBrand.Id);
                    conn.Brand.Attach(brandToUpdate);
                    brandToUpdate.Name = changedBrand.Name;
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

        public bool DeleteBrand(BrandDO brandToDelete)
        {
            try
            {                
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Attach(brandToDelete);
                    conn.Brand.Remove(brandToDelete);
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