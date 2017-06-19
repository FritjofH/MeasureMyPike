using System.Collections.Generic;
using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;
using MeasureMyPike.Application.Interfaces;

namespace MeasureMyPike.Controllers
{
    public class FishController : ApiController
    {
        private IFishService iFishService;
        private FishController()
        {
            iFishService = new FishService();
        }

        //GET: api/Fish
        public Fish Get(int id)
        {
            var fish = iFishService.GetFish(id);
            return fish;
        }

        // POST: api/Fish
        public Fish Post([FromBody]int Id, [FromBody]string Length, [FromBody]string Weight)
        {
            var fish = iFishService.UpdateFish(Id, Length, Weight);
            return fish;
        }
    }
}