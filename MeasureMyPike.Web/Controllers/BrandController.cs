using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;

using System.Net;
using System.Net.Http;


namespace MeasureMyPike.Controllers
{

    public class BrandController : ApiController
    {
        private IBrandService iBrandService;
        private BrandController()
        {
            iBrandService = new BrandService();
        }

        //GET: api/Brand
        public HttpResponseMessage Get()
        {
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
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Brand brand)
        {            
            var lbrand = iBrandService.AddBrand(brand.name);
            if (lbrand == null)
            {
                var message = string.Format("Could not add brand");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, lbrand);
            }
        }

        // PUT: api/Brand/
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Brand brand)
        {
            //var bs = new BrandService();
            var ibrand = iBrandService.UpdateBrand(brand.id, brand.name);
            if (ibrand == null)
            {
                var message = string.Format("Could not update brand");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, ibrand);
            }
        }

        // DELETE: api/Brand/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            //var bs = new BrandService();
            var deleted = iBrandService.DeleteBrand(id);


            if (deleted == false)
            {
                var message = string.Format("Could not delete brand");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, deleted);
            }
        }
    }
}
