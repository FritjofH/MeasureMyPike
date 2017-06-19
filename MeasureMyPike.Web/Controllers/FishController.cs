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

        [HttpPost]
        public Fish Post(Fish inputFish)
        {
            return iFishService.UpdateFish(inputFish.id, inputFish.length, inputFish.weight);
        }


    }
}