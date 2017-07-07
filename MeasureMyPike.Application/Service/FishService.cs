using MeasureMyPike.Application.Common;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Application.Interfaces;

namespace MeasureMyPike.Service
{
    public class FishService : IFishService
    {
        public Fish GetFish(int id)
        {
            var conversionService = new ConversionUtil();
            var fishRepo = new FishRepository();
            var selectedFish = fishRepo.GetFish(id);

            return conversionService.ConvertToFish(selectedFish);
        }

        public FishDO GetFishDO(int id)
        {
            var fishRepo = new FishRepository();
            var selectedFish = fishRepo.GetFish(id);

            return selectedFish;
        }

        public bool DeleteFish(int id)
        {
            var fishRepo = new FishRepository();
            var deleted = fishRepo.DeleteFish(id);
            return deleted;
        }

        public bool UpdateFish(int id, string length, string weight)
        {
            var conversionService = new ConversionUtil();
            var fishRepo = new FishRepository();
            return fishRepo.UpdateFish(id, length, weight);
        }
    }
}