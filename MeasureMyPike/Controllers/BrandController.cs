using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeasureMyPike.Service;
using System.Collections;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Controllers
{
    public class BrandController : ApiController
    {
        //GET: api/Brand
        public List<Brand> Get()
        {
            var bs = new BrandService();
            var brands = bs.GetAllBrands();

            return brands;
        }

        // GET: api/Brand/5
        public Brand Get(int id)
        {
            var bs = new BrandService();
            var brand = bs.GetBrand(id);

            return brand;
        }

        // POST: api/Brand
        public Brand Post([FromBody]string name)
        {
            var bs = new BrandService();
            var brand = bs.AddBrand(name);

            return brand;
        }

        // PUT: api/Brand/5
        public Brand Put(int id, [FromBody]string name)
        {
            var bs = new BrandService();
            var brand = bs.UpdateBrand(id, name);

            return brand;
        }

        // DELETE: api/Brand/5
        public bool Delete(int id)
        {
            var bs = new BrandService();
            var removed = bs.DeleteBrand(id);
            
            return removed;
        }
    }
}
