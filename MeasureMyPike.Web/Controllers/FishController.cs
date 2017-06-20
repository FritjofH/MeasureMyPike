using System.Collections.Generic;
using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;
using MeasureMyPike.Application.Interfaces;
using System.Net.Http;
using System.Net;

namespace MeasureMyPike.Controllers
{
    public class FishController : ApiController
    {
        private IFishService iFishService;
        private FishController()
        {
            iFishService = new FishService();
        }

        // PUT: api/Fish/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var fish = iFishService.GetFish(id);
            if (fish == null)
            {
                var message = string.Format("Could not find fish with id: {0}", id);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, fish);
            }
        }

        [HttpPost]
        public Fish Post(Fish inputFish)
        {
            return iFishService.UpdateFish(inputFish.id, inputFish.length, inputFish.weight);
        }

        //public bool Delete(int id)
        //{
        //    return iFishService.DeleteFish(id);
        //}
    }
}
