using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public class BrandRepository
    {

        public bool AddBrand(Brand brand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Add(brand);
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

        public List<Models.Application.Brand> GetAllBrands()
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brands = conn.Brand.ToList();

                    var brandList = new List<Models.Application.Brand>();

                    foreach (var brand in brands)
                    {
                        brandList.Add(new Models.Application.Brand { Id = brand.Id, Name = brand.Name });
                    }

                    return brandList;
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

        public Brand GetBrand(int id)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Brand brand = conn.Brand.First(u => u.Id == id);
                    return brand;
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

        public Brand GetBrand(string name)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Brand brand = conn.Brand.First(u => u.Name == name);
                    return brand;
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

        public bool UpdateBrand(int id, string name)
        {
            using (var conn = new ModelContainer())
            {
                try
                {
                    Brand b = conn.Brand.FirstOrDefault(it => it.Id == id);
                    b.Name = name;
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


    }
}