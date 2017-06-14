using System;
using System.Collections.Generic;
using System.Linq;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class BrandRepository
    {

        public BrandDO AddBrand(BrandDO newBrand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brand = conn.Brand.Add(newBrand);
                    conn.SaveChanges();

                    return brand;
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

        public List<BrandDO> GetAllBrands()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brands = conn.Brand.ToList();

                    return brands;
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

        public BrandDO GetBrand(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brand = conn.Brand.First(u => u.Id == id);

                    return brand;
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

        internal object DeleteBrand(int id)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brandToRemove = conn.Brand.First(it => it.Id == id);

                    conn.Brand.Remove(brandToRemove);
                    conn.SaveChanges();

                    return true;
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

        public BrandDO UpdateBrand(int id, string name)
        {
            try
            {
                using (var conn = new ModelContainer())
                {

                    var brand = conn.Brand.FirstOrDefault(it => it.Id == id);
                    brand.Name = name;
                    conn.SaveChanges();

                    return brand;
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


    }
}