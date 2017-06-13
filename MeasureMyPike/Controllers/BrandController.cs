using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Service;
using System.Collections;

namespace MeasureMyPike.Controllers
{
    public class BrandController : ApiController
    {
        //GET: api/Brand
        public List<Models.Application.Brand> Get()
        {
            BrandService bs = new BrandService();
            var brands = bs.getAllBrand();
            return brands;
        }

        // GET: api/Brand/5
        public Brand Get(int id)
        {
            BrandService bs = new BrandService();
            var b = bs.getBrand(id);
            return b;
        }

        // POST: api/Brand
        public void Post([FromBody]Brand value)
        {
            BrandService bs = new BrandService();
            bs.AddBrand(value);
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
            BrandService bs = new BrandService();
            bs.setBrand(id, value);
            
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
