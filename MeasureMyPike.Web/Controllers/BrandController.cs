using System.Collections.Generic;
using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;

using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MeasureMyPike.Controllers
{
    
    public class BrandController : ApiController
    {
        private IBrandService iBrandService;
        private BrandController() {
            iBrandService = new BrandService();
        }

        //GET: api/Brand
        public HttpResponseMessage Get()
        {
            //var bs = new BrandService();
            var brands = iBrandService.GetAllBrands();
            if (brands == null)
            {
                var message = string.Format("No Brands found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, brands);
            }
        }

        // GET: api/Brand/5
        public HttpResponseMessage Get(int id)
        {
            //var bs = new BrandService();
            var brand = iBrandService.GetBrand(id);
            if (brand == null)
            {
                var message = string.Format("Brand with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, brand);
            }
        }

        // POST: api/Brand
        public HttpResponseMessage Post([FromBody]Brand name)
        {
           var bs = new BrandService();
            var brand = iBrandService.AddBrand(name.Name);
            if (brand == null)
            {
                var message = string.Format("Could not add brand");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, brand);
            }
        }

        // PUT: api/Brand/5
        public HttpResponseMessage Put(int id, [FromBody]string name)
        {
            //var bs = new BrandService();
            var brand = iBrandService.UpdateBrand(id, name);
            if (brand == null)
            {
                var message = string.Format("Could not update brand");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, brand);
            }            
        }

        // DELETE: api/Brand/5
        public bool Delete(int id)
        {
            //var bs = new BrandService();
            var deleted = iBrandService.DeleteBrand(id);
            
            return deleted;
        }
    }
}
