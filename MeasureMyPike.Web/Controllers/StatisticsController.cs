using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeasureMyPike.Controllers
{
    public class StatisticsController : ApiController
    {
        private IStatisticsService iStatisticsService;
        private StatisticsController()
        {
            iStatisticsService = new StatisticsService();
        }

        // GET: api/Statistics
        public HttpResponseMessage Get()
        {
            var statList = iStatisticsService.GetAllStatistics();
            if (statList == null)
            {
                var message = string.Format("No Statistics found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, statList);
            }
        }

        [Route("api/Statistics/perUser")]
        [HttpGet]
        public HttpResponseMessage GetPerUser(string username, string startDate)
        {
            var catchList = iStatisticsService.CatchesForUser(username, System.Convert.ToDateTime(startDate));
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

        [Route("api/Statistics/perLake")]
        [HttpGet]
        public HttpResponseMessage GetPerLake(string lakename, string startDate)
        {
            var catchList = iStatisticsService.CatchesForLake(lakename, System.Convert.ToDateTime(startDate));
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

        [Route("api/Statistics/topLake")]
        [HttpGet]
        public HttpResponseMessage GetTopLake(string startDate)
        {
            var topList = iStatisticsService.LakeTopList(System.Convert.ToDateTime(startDate));
            if (topList == null)
            {
                var message = string.Format("No Catches found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, topList);
            }
        }

        [Route("api/Statistics/topFish")]
        [HttpGet]
        public HttpResponseMessage GetTopFish(int catches, string startDate)
        {
            var topList = iStatisticsService.FishTopList(catches, System.Convert.ToDateTime(startDate));
            if (topList == null)
            {
                var message = string.Format("No Fish found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, topList);
            }
        }

        [Route("api/Statistics/latestCatch")]
        [HttpGet]
        public HttpResponseMessage GetLatestCatch(int catches)
        {
            var topList = iStatisticsService.LatestCatches(catches);
            if (topList == null)
            {
                var message = string.Format("No Fish found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, topList);
            }
        }

    }
}
