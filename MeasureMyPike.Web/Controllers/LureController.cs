using System.Web.Http;
using MeasureMyPike.Service;
using System.Net.Http;
using System.Net;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Controllers
{
    public class LureController : ApiController
    {
        private ILureService iLureService;
        private LureController()
        {
            iLureService = new LureService();
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var lure = iLureService.GetLure(id);
            if (lure == null)
            {
                var message = string.Format("Could not find a lure with id: {0}", id);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, lure);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Lure inputLure)
        {
            var ilure = iLureService.UpdateLure(inputLure.id, inputLure.brandId, inputLure.name, inputLure.weight, inputLure.colour);
            if (ilure == null)
            {
                var message = string.Format("Could not find fish with id: {0}", inputLure.id);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, ilure);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Lure inputLure)
        {
            var ilure = iLureService.AddLure(inputLure.name, inputLure.brandId, inputLure.weight, inputLure.colour);
            if (ilure == null)
            {
                var message = string.Format("Could not find fish with id: {0}", inputLure.id);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, ilure);
            }
        }
    }
}