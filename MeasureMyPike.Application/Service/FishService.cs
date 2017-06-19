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
            var conversionService = new ConversionService();
            var fishRepo = new FishRepository();
            var selectedFish = fishRepo.GetFish(id);

            return conversionService.convertToFish(selectedFish);
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
            var fishToDelete = GetFishDO(id);
            var deleted = fishRepo.DeleteFish(fishToDelete);
            return deleted;
        }

        public Fish UpdateFish(int id, string length, string weight)
        {
            var conversionService = new ConversionService();
            var fishRepo = new FishRepository();
            var updatedFish = fishRepo.UpdateFish(id, length, weight);

            return conversionService.convertToFish(updatedFish);
        }
    }
}