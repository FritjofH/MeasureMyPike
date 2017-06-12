using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeasureMyPike.Models;
using MeasureMyPike.Service;
using System.Collections;

namespace MeasureMyPike.Controllers
{
    public class BrandController : ApiController
    {
        //GET: api/Brand
        public List<Brand> Get()
        {
            BrandService bs = new BrandService();
            var e = bs.getAllBrand();
            return e;
        }

        // GET: api/Brand/5
        public string Get(int id)
        {
            return "value";
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
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
