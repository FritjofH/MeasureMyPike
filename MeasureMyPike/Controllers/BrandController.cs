using System.Collections.Generic;
using System.Web.Http;
using MeasureMyPike.Service;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Controllers
{
    
    public class BrandController : ApiController
    {
        private IBrandService iBrandService;
        private BrandController() {
            iBrandService = new BrandService();
        }

        //GET: api/Brand
        public List<Brand> Get()
        {
            //var bs = new BrandService();
            var brands = iBrandService.GetAllBrands();

            return brands;
        }

        // GET: api/Brand/5
        public Brand Get(int id)
        {
            //var bs = new BrandService();
            var brand = iBrandService.GetBrand(id);

            return brand;
        }

        // POST: api/Brand
        public Brand Post([FromBody]string name)
        {
            //var bs = new BrandService();
            var brand = iBrandService.AddBrand(name);

            return brand;
        }

        // PUT: api/Brand/5
        public Brand Put(int id, [FromBody]string name)
        {
            //var bs = new BrandService();
            var brand = iBrandService.UpdateBrand(id, name);

            return brand;
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
