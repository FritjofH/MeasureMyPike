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
                    var createdBrand = conn.Brand.Add(newBrand);
                    conn.SaveChanges();

                    return createdBrand;
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
                    var selectedBrand = conn.Brand.First(u => u.Id == id);

                    return selectedBrand;
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
                    var brandList = conn.Brand.ToList();

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

        public BrandDO UpdateBrand(BrandDO changedBrand)
        {
            try
            {
                using (var conn = new ModelContainer())
                {
                    var brandToUpdate = conn.Brand.FirstOrDefault(it => it.Id == changedBrand.Id);
                    brandToUpdate.Name = changedBrand.Name;
                    conn.SaveChanges();

                    return brandToUpdate;
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

        public bool DeleteBrand(int brandToDelete)
        {
            try
            {
                BrandDO brnd = GetBrand(brandToDelete);
                using (var conn = new ModelContainer())
                {
                    conn.Brand.Attach(brnd);
                    conn.Brand.Remove(brnd);
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
    }
}