using MeasureMyPike.Models.Application;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeasureMyPike.Controllers
{
    public class CatchController : ApiController
    {
        private ICatchService iCatchService;
        private CatchController()
        {
            iCatchService = new CatchService();
        }
        // GET: api/Catch
      
            
        public HttpResponseMessage Get()
        {
            var catchList = iCatchService.GetAllCatches();
            if (catchList == null)
            {
                var message = string.Format("No Catches found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, catchList);
            }
        }

        // GET: api/Catch/5
        public HttpResponseMessage Get(int id)
        {
            var catchList = iCatchService.GetCatch(id);
            if (catchList == null)
            {
                var message = string.Format("No Catches found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, catchList);
            }
        }
        
//        // POST: api/Catch
//        [HttpPost]
//        public HttpResponseMessage Post([FromBody]Catch catch2)
//        {
////byte[] image, string format, string comment, Lure lure, string fishWeight, string fishLength, string lake, string coordinates, int temperature, string weather, string moonposition, string username)
    
//            var lbrand = iCatchService.AddCatch(catch2.mediaId, null, catch2.commentId);
//            if (lbrand == null)
//            {
//                var message = string.Format("Could not add brand");
//                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
//            }
//            else
//            {
//                return Request.CreateResponse(HttpStatusCode.OK, lbrand);
//            }
//        }

        // PUT: api/Catch/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
        }

        // DELETE: api/Catch/5
        public bool Delete(int id)
        {
            var cs = new CatchService();
            var deleted = cs.DeleteCatch(id);

            return deleted;
        }
    }
}
